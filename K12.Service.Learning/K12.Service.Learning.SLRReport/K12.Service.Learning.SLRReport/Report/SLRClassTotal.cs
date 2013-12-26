using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using System.Diagnostics;
using Aspose.Words;

namespace K12.Service.Learning.SLRReport
{
    public partial class SLRClassTotal : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        FISCA.UDT.AccessHelper _accessHelper = new FISCA.UDT.AccessHelper();

        FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

        int _SchoolYear { get; set; }

        int _Semester { get; set; }

        string 服務學習班級統計表設定檔 = "K12.Service.Learning.Modules.Config.SLRClassTotal.cs";

        Document _doc = new Document(); //主文件
        Run _run; //移動使用
        Document _template;

        public SLRClassTotal()
        {
            InitializeComponent();
        }

        private void SLRClassTotal_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            integerInput1.Text = K12.Data.School.DefaultSchoolYear;
            integerInput2.Text = K12.Data.School.DefaultSemester;

            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(服務學習班級統計表設定檔);
            //如果沒有設定過樣板
            if (ConfigurationInCadre.Template == null)
            {
                //預設樣板 & 格式
                ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數學期統計表_範本, Campus.Report.TemplateType.Word);
                ConfigurationInCadre.Save();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!BGW.IsBusy)
            {
                _SchoolYear = integerInput1.Value;
                _Semester = integerInput2.Value;

                BGW.RunWorkerAsync();


            }
            else
            {
                MsgBox.Show("系統忙碌中,請稍後再試!!");
            }
        }


        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得目前所選班級資料
            List<string> _ClassIDList = K12.Presentation.NLDPanels.Class.SelectedSource;

            //取得班級學生資料
            List<StudentTotalObj> studentList = GetStudentOBJ(_ClassIDList);

            //組合班級清單
            List<ClassTotalObj> classList = GetClassOBJ(_ClassIDList);

            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(服務學習班級統計表設定檔);
            _template = ConfigurationInCadre.Template.ToDocument();
            _doc.Sections.Clear();

            foreach (StudentTotalObj each1 in studentList)
            {
                foreach (ClassTotalObj each2 in classList)
                {
                    if (each1.ref_class_id == each2.ref_class_id)
                    {
                        each2.StudentObjList.Add(each1);

                        if (!each2.StudentIDList.Contains(each1.ref_student_id))
                        {
                            each2.StudentIDList.Add(each1.ref_student_id);
                        }

                        if (!each2.StudentDic.ContainsKey(each1.ref_student_id))
                        {
                            each2.StudentDic.Add(each1.ref_student_id, each1);
                        }
                    }
                }
            }

            //取得學生統計結果
            List<string> studentIDList = GetStudentID(studentList);
            string qu = string.Join("','", studentIDList);
            List<SLRecord> SLRList = _accessHelper.Select<SLRecord>("ref_student_id in ('" + qu + "') and school_year=" + _SchoolYear + " and semester=" + _Semester);

            foreach (SLRecord each in SLRList)
            {
                foreach (ClassTotalObj each2 in classList)
                {
                    if (each2.StudentIDList.Contains(each.RefStudentID))
                    {
                        each2.SetSLRInStudent(each);
                    }
                }
            }

            classList.Sort(SortClass);

            //班級
            foreach (ClassTotalObj each1 in classList)
            {
                if (each1.StudentIDList.Count > 0)
                {
                    Document PageOne = SetDocument(each1);

                    if (PageOne != null)
                    {
                        _doc.Sections.Add(_doc.ImportNode(PageOne.FirstSection, true));
                    }
                }
            }

            e.Result = _doc;
        }

        private Document SetDocument(ClassTotalObj each1)
        {
            //排序
            each1.StudentObjList.Sort(SortStudent);

            Document PageOne = (Document)_template.Clone(true);
            _run = new Run(PageOne);
            DocumentBuilder builder = new DocumentBuilder(PageOne);
            builder.MoveToMergeField("資料");
            Cell cell = (Cell)builder.CurrentParagraph.ParentNode;


            //需要Insert Row
            //取得目前Row
            Row 日3row = (Row)cell.ParentRow;

            for (int x = 1; x < each1.StudentIDList.Count; x++)
            {
                cell.ParentRow.ParentTable.InsertAfter(日3row.Clone(true), cell.ParentNode);
            }

            //學生ID
            foreach (StudentTotalObj each2 in each1.StudentObjList)
            {
                //座號
                Write(cell, each2.seat_no);
                cell = GetMoveRightCell(cell, 1);
                //姓名
                Write(cell, each2.student_name);
                cell = GetMoveRightCell(cell, 1);
                //學號
                Write(cell, each2.student_number);
                cell = GetMoveRightCell(cell, 1);
                //性別
                Write(cell, each2.student_gender);
                cell = GetMoveRightCell(cell, 1);
                //統計
                Write(cell, each2.學期1統計.ToString());
                //cell = GetMoveRightCell(cell, 1);
                //需補時數
                //Write(cell, each2.需補時數.ToString());

                Row Nextrow = cell.ParentRow.NextSibling as Row; //取得下一行
                if (Nextrow == null)
                {
                    break;
                }
                cell = Nextrow.FirstCell; //第一格
            }

            #region MailMerge

            List<string> name = new List<string>();
            List<string> value = new List<string>();

            name.Add("班級");
            value.Add(each1.class_name);

            name.Add("導師");
            value.Add(each1.GetTeacherName());

            name.Add("學年度");
            value.Add(_SchoolYear.ToString());

            name.Add("學期");
            value.Add(_Semester.ToString());

            PageOne.MailMerge.Execute(name.ToArray(), value.ToArray());

            #endregion

            return PageOne;
        }

        /// <summary>
        /// 以Cell為基準,向右移一格
        /// </summary>
        private Cell GetMoveRightCell(Cell cell, int count)
        {
            if (count == 0) return cell;

            Row row = cell.ParentRow;
            int col_index = row.IndexOf(cell);
            Table table = row.ParentTable;
            int row_index = table.Rows.IndexOf(row);

            try
            {
                return table.Rows[row_index].Cells[col_index + count];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 寫入資料
        /// </summary>
        private void Write(Cell cell, string text)
        {
            if (cell.FirstParagraph == null)
                cell.Paragraphs.Add(new Paragraph(cell.Document));
            cell.FirstParagraph.Runs.Clear();
            _run.Text = text;
            _run.Font.Size = 10;
            _run.Font.Name = "標楷體";
            cell.FirstParagraph.Runs.Add(_run.Clone(true));
        }

        /// <summary>
        /// 排序:座號/姓名
        /// </summary>
        private int SortStudent(StudentTotalObj obj1, StudentTotalObj obj2)
        {
            string seatno1 = obj1.seat_no.PadLeft(3, '0');
            seatno1 += obj1.student_name.PadLeft(10, '0');

            string seatno2 = obj2.seat_no.PadLeft(3, '0');
            seatno2 += obj2.student_name.PadLeft(10, '0');

            return seatno1.CompareTo(seatno2);
        }

        /// <summary>
        /// 排序:年級/班級序號/班級名稱
        /// </summary>
        private int SortClass(ClassTotalObj obj1, ClassTotalObj obj2)
        {
            //年級
            string seatno1 = obj1.class_grade_year.PadLeft(1, '0');
            seatno1 += obj1.class_index.PadLeft(3, '0');
            seatno1 += obj1.class_name.PadLeft(10, '0');

            string seatno2 = obj2.class_grade_year.PadLeft(1, '0');
            seatno2 += obj2.class_index.PadLeft(3, '0');
            seatno2 += obj2.class_name.PadLeft(10, '0');

            return seatno1.CompareTo(seatno2);
        }

        private List<string> GetStudentID(List<StudentTotalObj> studentList)
        {
            return studentList.Select(x => x.ref_student_id).ToList();
        }

        private List<ClassTotalObj> GetClassOBJ(List<string> _ClassIDList)
        {
            List<ClassTotalObj> list = new List<ClassTotalObj>();
            string classid = string.Join("','", _ClassIDList);
            string qu = "select class.id,class.class_name,teacher.id as teacher_id,teacher.teacher_name,teacher.nickname,class.grade_year,class.display_order ";
            qu += "from class LEFT join teacher on class.ref_teacher_id=teacher.id ";
            qu += "where class.id in('" + classid + "')";
            DataTable dt = _queryHelper.Select(qu);

            foreach (DataRow row in dt.Rows)
            {
                ClassTotalObj obj = new ClassTotalObj(row);
                list.Add(obj);
            }
            return list;

        }

        private List<StudentTotalObj> GetStudentOBJ(List<string> _ClassIDList)
        {
            List<StudentTotalObj> list = new List<StudentTotalObj>();
            //取得班級學生資料
            string qu = "select student.id,class.id as class_id,student.seat_no,student.student_number,student.name,student.status,student.gender from student join class on class.id=student.ref_class_id where class.id in('" + string.Join("','", _ClassIDList) + "')";
            DataTable dt = _queryHelper.Select(qu);

            foreach (DataRow row in dt.Rows)
            {
                StudentTotalObj obj = new StudentTotalObj(row);
                //學生不等於 刪除 與 畢業及離校
                if (obj.status != "16" && obj.status != "256")
                {
                    list.Add(obj);
                }
            }
            return list;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MsgBox.Show("列印作業已中止!!");
                return;
            }

            if (e.Error == null)
            {
                Document inResult = (Document)e.Result;

                try
                {
                    SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

                    SaveFileDialog1.Filter = "Word (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                    SaveFileDialog1.FileName = "班級服務學習統計表";

                    if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        inResult.Save(SaveFileDialog1.FileName);
                        Process.Start(SaveFileDialog1.FileName);
                    }
                    else
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("檔案未儲存");
                        return;
                    }
                }
                catch
                {
                    FISCA.Presentation.Controls.MsgBox.Show("檔案儲存錯誤,請檢查檔案是否開啟中!!");
                    return;
                }

                this.Close();
            }
            else
            {
                MsgBox.Show("列印發生錯誤:\n" + e.Error.Message);
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(服務學習班級統計表設定檔);
            //畫面內容(範本內容,預設樣式
            Campus.Report.TemplateSettingForm TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數學期統計表_範本, Campus.Report.TemplateType.Word));
            //預設名稱
            TemplateForm.DefaultFileName = "班級服務學習統計表(範本)";
            //如果回傳為OK
            if (TemplateForm.ShowDialog() == DialogResult.OK)
            {
                //設定後樣試,回傳
                ConfigurationInCadre.Template = TemplateForm.Template;
                //儲存
                ConfigurationInCadre.Save();
            }
        }
    }
}
