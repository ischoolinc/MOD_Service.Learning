using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using K12.Data;
using FISCA.UDT;
using Aspose.Words;
using System.Diagnostics;
using System.IO;

namespace K12.Service.Learning.Modules
{
    public partial class SLReportForm : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        Document _doc = new Document(); //主文件
        Run _run; //移動使用
        Document _template;

        Dictionary<string, StudentRecord> StudentDic = new Dictionary<string, StudentRecord>();

        List<string> SchoolYearNameList = new List<string>() { "學年度/學期1", "學年度/學期2", "學年度/學期3", "學年度/學期4", "學年度/學期5", "學年度/學期6", "學年度/學期7", "學年度/學期8", "學年度/學期9", "學年度/學期10", "學年度/學期11", "學年度/學期12" };

        /// <summary>
        /// 預設列印模式(1)所有資料(2)依學年度(3)依
        /// </summary>
        NowSelect PrintMode = NowSelect.rbByAllData;

        /// <summary>
        /// 列印日期時,是依發生日期還是依登錄日期
        /// </summary>
        bool PrintByDate_IsStartOrInsert = true;

        int SchoolYear { get; set; }
        int Semester { get; set; }

        DateTime PrintStart { get; set; }
        DateTime PrintEnd { get; set; }

        string ServiceLearningConfig = "K12.Service.Learning.Modules.Config_0910";

        AccessHelper _accessHelper = new AccessHelper();

        bool print_SLR_InZero = false;

        public SLReportForm()
        {
            InitializeComponent();
        }

        private void SLReportForm_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            intSchoolYear.Value = int.Parse(School.DefaultSchoolYear);
            intSemester.Value = int.Parse(School.DefaultSemester);

            dtStart.Value = DateTime.Today.AddDays(-7);
            dtEnd.Value = DateTime.Today;

            RunFormDn();

            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ServiceLearningConfig);
            //如果沒有設定過樣板
            if (ConfigurationInCadre.Template == null)
            {
                //預設樣板 & 格式
                ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習記錄_範本, Campus.Report.TemplateType.Word);
                ConfigurationInCadre.Save();
            }
        }
        private void RunFormDn()
        {
            dtStart.Enabled = false;
            dtEnd.Enabled = false;
            intSchoolYear.Enabled = false;
            intSemester.Enabled = false;
            rbByStartDate.Enabled = false;
            tbByInsertDate.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!BGW.IsBusy)
            {
                SetEnabled = false;
                print_SLR_InZero = checkBoxX1.Checked;
                if (rbBySchoolYearAndSemester.Checked)
                {
                    PrintMode = NowSelect.rbBySchoolYearAndSemester;
                    SchoolYear = intSchoolYear.Value;
                    Semester = intSemester.Value;
                }
                else if (rbByDateRange.Checked)
                {
                    PrintMode = NowSelect.rbByDateRange;
                    PrintStart = dtStart.Value;
                    PrintEnd = dtEnd.Value;

                    if (rbByStartDate.Checked) //依發生日期
                    {
                        PrintByDate_IsStartOrInsert = true;
                    }
                    else
                    {
                        PrintByDate_IsStartOrInsert = false;
                    }
                }

                BGW.RunWorkerAsync();
            }
            else
            {
                MsgBox.Show("系統忙碌中,稍後再試!");
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得學生
            StudentDic = GetStudentDic();

            //取得服務學習時數
            Dictionary<string, List<SLRecord>> SLRecordDic = GetRecordDic();

            #region 當使用者勾選列印無時數學生時

            Dictionary<string, List<SLRecord>> SLRecordZeroDic = new Dictionary<string, List<SLRecord>>();

            if (print_SLR_InZero)
            {
                foreach (string each in K12.Presentation.NLDPanels.Student.SelectedSource)
                {
                    if (!SLRecordDic.ContainsKey(each))
                    {
                        SLRecord s = new SLRecord();
                        s.Hours = 0;
                        s.RefStudentID = each;
                        SLRecordZeroDic.Add(each, new List<SLRecord>() { s });
                    }
                }

                SLRecordZeroDic = SortSpeed(SLRecordZeroDic);
            } 
            #endregion

            //排序總體學生資料
            SLRecordDic = SortSpeed(SLRecordDic);

            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ServiceLearningConfig);
            _template = ConfigurationInCadre.Template.ToDocument();
            _doc.Sections.Clear();

            //學生要照班級/座號/排序
            //學生資料照日期排序

            foreach (string each in SLRecordDic.Keys) //取得一名學生Key
            {
                List<SLRecord> list = SLRecordDic[each];
                list.Sort(SortDate); //排序學生個人資料
                Document PageOne = SetDocument(list);

                if (PageOne != null)
                {
                    _doc.Sections.Add(_doc.ImportNode(PageOne.FirstSection, true));
                }
            }

            if (print_SLR_InZero)
            {
                foreach (string each in SLRecordZeroDic.Keys) //取得一名學生Key
                {
                    List<SLRecord> list = SLRecordZeroDic[each];
                    Document PageOne = SetZeroDocument(list);

                    if (PageOne != null)
                    {
                        _doc.Sections.Add(_doc.ImportNode(PageOne.FirstSection, true));
                    }
                }
            }
            e.Result = _doc;
        }

        private Dictionary<string, List<SLRecord>> SortSpeed(Dictionary<string, List<SLRecord>> dic)
        {
            Dictionary<string, List<SLRecord>> dicReturn = new Dictionary<string, List<SLRecord>>();
            List<string> StudentIDList = dic.Keys.ToList();
            List<StudentRecord> StudentList = SortClassIndex.K12Data_StudentRecord(Student.SelectByIDs(StudentIDList));
            foreach (StudentRecord sr in StudentList)
            {
                if (!dicReturn.ContainsKey(sr.ID))
                {
                    dicReturn.Add(sr.ID, new List<SLRecord>());
                }
                dicReturn[sr.ID] = dic[sr.ID];
            }
            return dicReturn;
        }

        private int SortDate(SLRecord a, SLRecord b)
        {
            return a.OccurDate.CompareTo(b.OccurDate);
        }

        /// <summary>
        /// 取得選擇學生Record
        /// </summary>
        private Dictionary<string, StudentRecord> GetStudentDic()
        {
            Dictionary<string, StudentRecord> dic = new Dictionary<string, StudentRecord>();
            foreach (StudentRecord student in Student.SelectByIDs(K12.Presentation.NLDPanels.Student.SelectedSource))
            {
                if (!dic.ContainsKey(student.ID))
                {
                    dic.Add(student.ID, student);
                }
            }
            return dic;
        }

        private Document SetDocument(List<SLRecord> list)
        {
            Document PageOne = (Document)_template.Clone(true);

            StudentRecord sr = StudentDic[list[0].RefStudentID];

            //???
            _run = new Run(PageOne);
            //可建構的...
            DocumentBuilder builder = new DocumentBuilder(PageOne);

            builder.MoveToMergeField("資料");
            Cell cell = (Cell)builder.CurrentParagraph.ParentNode;

            //取得目前Row
            Row 日3row = (Row)cell.ParentRow;

            //除了原來的Row-1,高於1就多建立幾行
            for (int x = 1; x < list.Count; x++)
            {
                cell.ParentRow.ParentTable.InsertAfter(日3row.Clone(true), cell.ParentNode);
            }

            Dictionary<string, decimal> SchoolYearTotal = new Dictionary<string, decimal>();

            foreach (SLRecord slr in list)
            {
                string schoolYearValue = slr.SchoolYear.ToString().PadLeft(3, ' ') + "學年度 第" + slr.Semester + "學期";
                if (!SchoolYearTotal.ContainsKey(schoolYearValue))
                {
                    SchoolYearTotal.Add(schoolYearValue, 0);
                }
                SchoolYearTotal[schoolYearValue] += slr.Hours;

                //學年度
                Write(cell, "" + slr.SchoolYear);
                cell = GetMoveRightCell(cell, 1);

                //學期
                Write(cell, "" + slr.Semester);
                cell = GetMoveRightCell(cell, 1);

                //日期
                Write(cell, slr.OccurDate.ToShortDateString());
                cell = GetMoveRightCell(cell, 1);

                //事由
                Write(cell, slr.Reason);
                cell = GetMoveRightCell(cell, 1);

                //時數
                Write(cell, "" + slr.Hours);
                cell = GetMoveRightCell(cell, 1);

                //主辦單位
                Write(cell, "" + slr.Organizers);
                cell = GetMoveRightCell(cell, 1);

                //校內校外
                Write(cell, "" + slr.InternalOrExternal);
                cell = GetMoveRightCell(cell, 1);

                //備註
                Write(cell, "" + slr.Remark);

                Row Nextrow = cell.ParentRow.NextSibling as Row; //取得下一行
                if (Nextrow == null)
                {
                    break;
                }
                cell = Nextrow.FirstCell; //第一格


            }

            SchoolYearTotal = SortSchoolYear(SchoolYearTotal);

            #region MailMerge
            List<string> name = new List<string>();
            List<string> value = new List<string>();

            name.Add("學校");
            value.Add(School.ChineseName);

            name.Add("列印日期");
            value.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            name.Add("班級");
            value.Add(string.IsNullOrEmpty(sr.RefClassID) ? "" : sr.Class.Name);

            name.Add("座號");
            value.Add(sr.SeatNo.HasValue ? "" + sr.SeatNo.Value : "");

            name.Add("姓名");
            value.Add(sr.Name);

            name.Add("學號");
            value.Add(sr.StudentNumber);

            name.Add("性別");
            value.Add(sr.Gender);

            List<string> listkey = SchoolYearTotal.Keys.ToList();

            for (int x = 0; x < SchoolYearTotal.Count; x++)
            {
                if (x > 11)
                    break;

                name.Add(SchoolYearNameList[x]);

                value.Add(listkey[x] + " 總時數：" + SchoolYearTotal[listkey[x]].ToString());

            }

            foreach (string each in SchoolYearNameList)
            {
                if (!name.Contains(each))
                {
                    name.Add(each);
                    value.Add("");
                }
            }

            PageOne.MailMerge.Execute(name.ToArray(), value.ToArray());
            #endregion

            return PageOne;
        }

        /// <summary>
        /// 無時數學生之處理
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private Document SetZeroDocument(List<SLRecord> list)
        {
            Document PageOne = (Document)_template.Clone(true);

            StudentRecord sr = StudentDic[list[0].RefStudentID];

            //???
            _run = new Run(PageOne);
            //可建構的...
            DocumentBuilder builder = new DocumentBuilder(PageOne);

            builder.MoveToMergeField("資料");
            Cell cell = (Cell)builder.CurrentParagraph.ParentNode;

            Dictionary<string, decimal> SchoolYearTotal = new Dictionary<string, decimal>();

            foreach (SLRecord slr in list)
            {
                //備註
                cell = GetMoveRightCell(cell, 6);
                Write(cell, "(無時數資料)");
            }
            
            #region MailMerge
            List<string> name = new List<string>();
            List<string> value = new List<string>();

            name.Add("學校");
            value.Add(School.ChineseName);

            name.Add("列印日期");
            value.Add(DateTime.Now.ToString("yyyy/MM/dd HH:mm"));

            name.Add("班級");
            value.Add(string.IsNullOrEmpty(sr.RefClassID) ? "" : sr.Class.Name);

            name.Add("座號");
            value.Add(sr.SeatNo.HasValue ? "" + sr.SeatNo.Value : "");

            name.Add("姓名");
            value.Add(sr.Name);

            name.Add("學號");
            value.Add(sr.StudentNumber);

            name.Add("性別");
            value.Add(sr.Gender);

            foreach (string each in SchoolYearNameList)
            {
                if (!name.Contains(each))
                {
                    name.Add(each);
                    value.Add("");
                }
            }

            PageOne.MailMerge.Execute(name.ToArray(), value.ToArray());
            #endregion

            return PageOne;
        }

        private Dictionary<string, decimal> SortSchoolYear(Dictionary<string, decimal> SchoolYearTotal)
        {
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();
            List<string> list = SchoolYearTotal.Keys.ToList();
            list.Sort();
            foreach (string each in list)
            {
                if (!dic.ContainsKey(each))
                {
                    dic.Add(each, 0);
                }
                dic[each] = SchoolYearTotal[each];
            }
            return dic;

        }

        private Dictionary<string, List<SLRecord>> GetRecordDic()
        {
            Dictionary<string, List<SLRecord>> dic = new Dictionary<string, List<SLRecord>>();

            #region list
            List<SLRecord> list = new List<SLRecord>();

            if (PrintMode == NowSelect.rbByAllData)
            {
                list = _accessHelper.Select<SLRecord>("ref_student_id in ('" + string.Join("','", K12.Presentation.NLDPanels.Student.SelectedSource) + "')");

            }
            else if (PrintMode == NowSelect.rbBySchoolYearAndSemester)
            {
                list = _accessHelper.Select<SLRecord>("ref_student_id in ('" + string.Join("','", K12.Presentation.NLDPanels.Student.SelectedSource) + "') and school_year='" + SchoolYear + "' and semester='" + Semester + "'");
            }
            else if (PrintMode == NowSelect.rbByDateRange)
            {
                List<SLRecord> list1 = new List<SLRecord>();
                list1 = _accessHelper.Select<SLRecord>("ref_student_id in ('" + string.Join("','", K12.Presentation.NLDPanels.Student.SelectedSource) + "')");
                if (PrintByDate_IsStartOrInsert)
                {
                    foreach (SLRecord each in list1)
                    {
                        if (each.OccurDate.CompareTo(PrintStart) >= 0 && each.OccurDate.CompareTo(PrintEnd) <= 0)
                        {
                            list.Add(each);
                        }
                    }
                }
                else
                {
                    foreach (SLRecord each in list1)
                    {
                        if (each.RegisterDate.CompareTo(PrintStart) >= 0 && each.RegisterDate.CompareTo(PrintEnd) <= 0)
                        {
                            list.Add(each);
                        }
                    }
                }

            }
            #endregion

            foreach (SLRecord slr in list)
            {
                if (!dic.ContainsKey(slr.RefStudentID))
                {
                    dic.Add(slr.RefStudentID, new List<SLRecord>());
                }
                dic[slr.RefStudentID].Add(slr);
            }

            return dic;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            SetEnabled = true;

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
                    SaveFileDialog1.FileName = "服務學習時數證明單";

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

        private bool SetEnabled
        {
            set
            {
                btnStart.Enabled = value;
                dtStart.Enabled = value;
                dtEnd.Enabled = value;
                intSchoolYear.Enabled = value;
                intSemester.Enabled = value;
                rbByAllData.Enabled = value;
                rbBySchoolYearAndSemester.Enabled = value;
                rbByDateRange.Enabled = value;
                rbByStartDate.Enabled = value;
                tbByInsertDate.Enabled = value;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ServiceLearningConfig);
            //畫面內容(範本內容,預設樣式
            Campus.Report.TemplateSettingForm TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習記錄_範本, Campus.Report.TemplateType.Word));
            //預設名稱
            TemplateForm.DefaultFileName = "服務學習時數證明單(範本)";
            //如果回傳為OK
            if (TemplateForm.ShowDialog() == DialogResult.OK)
            {
                //設定後樣試,回傳
                ConfigurationInCadre.Template = TemplateForm.Template;
                //儲存
                ConfigurationInCadre.Save();
            }
        }

        private void rbByAllData_CheckedChanged(object sender, EventArgs e)
        {
            dtStart.Enabled = false;
            dtEnd.Enabled = false;
            rbByStartDate.Enabled = false;
            tbByInsertDate.Enabled = false;
            intSchoolYear.Enabled = false;
            intSemester.Enabled = false;
        }

        private void rbBySchoolYearAndSemester_CheckedChanged(object sender, EventArgs e)
        {
            dtStart.Enabled = false;
            dtEnd.Enabled = false;
            rbByStartDate.Enabled = false;
            tbByInsertDate.Enabled = false;
            intSchoolYear.Enabled = true;
            intSemester.Enabled = true;
        }

        private void rbByDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dtStart.Enabled = true;
            dtEnd.Enabled = true;
            rbByStartDate.Enabled = true;
            tbByInsertDate.Enabled = true;
            intSchoolYear.Enabled = false;
            intSemester.Enabled = false;
        }
    }

    enum NowSelect
    {
        /// <summary>
        /// 取得所有資料
        /// </summary>
        rbByAllData,
        /// <summary>
        /// 依學年度學期取得資料
        /// </summary>
        rbBySchoolYearAndSemester,
        /// <summary>
        /// 依日期區間取得資料
        /// </summary>
        rbByDateRange
    }
}
