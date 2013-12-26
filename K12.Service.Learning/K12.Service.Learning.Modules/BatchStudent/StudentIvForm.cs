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

namespace K12.Service.Learning.Modules
{
    public partial class StudentIvForm : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        Congig c { get; set; }
        public StudentIvForm()
        {
            InitializeComponent();
        }

        private void StudentIvForm_Load(object sender, EventArgs e)
        {

            //當勾選使用學期條件時
            //必須打開功能項目

            //預設學年度學期
            integerInput1.Value = int.Parse(School.DefaultSchoolYear);
            integerInput2.Value = int.Parse(School.DefaultSemester);
            labelX4.Text = "待 處 理 學 生 ：" + K12.Presentation.NLDPanels.Student.TempSource.Count + " 人";

            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            dataGridViewX1.SelectionChanged += new EventHandler(dataGridViewX1_SelectionChanged);

            K12.Presentation.NLDPanels.Student.TempSourceChanged += new EventHandler(Student_TempSourceChanged);

            btnSelecta_Click(null, null);
        }

        void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count == 1)
            {
                查看明細資料ToolStripMenuItem.Enabled = true;
            }
            else
            {
                查看明細資料ToolStripMenuItem.Enabled = false;
            }
        }

        void Student_TempSourceChanged(object sender, EventArgs e)
        {
            labelX4.Text = "待 處 理 學 生 ：" + K12.Presentation.NLDPanels.Student.TempSource.Count + " 人";
        }

        private void btnSelecta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(errorProvider1.GetError(textBoxX1)))
            {

                if (!BGW.IsBusy)
                {
                    c = new Congig();
                    c.時數 = decimal.Parse(textBoxX1.Text);
                    c.是否使用學年期 = checkBoxX4.Checked;
                    c.學年度 = integerInput1.Value;
                    c.學期 = integerInput2.Value;

                    if (checkBoxX2.Checked)
                    {
                        c.比較 = 比數.小於;
                        if (c.時數 == 0 || c.時數 < 0)
                        {
                            MsgBox.Show("無法比較!!");
                            return;
                        }
                    }
                    else if (checkBoxX3.Checked)
                    {
                        c.比較 = 比數.無資料;
                    }
                    else
                    {
                        c.比較 = 比數.大於等於;
                    }
                    btnSelecta.Enabled = false;
                    this.Text = "學生服務時數查詢(全系統資料查詢中...)";
                    BGW.RunWorkerAsync();
                }
                else
                {
                    MsgBox.Show("忙碌中請稍後...");
                }
            }
            else
            {
                MsgBox.Show("查詢時數錯誤,請修正錯誤!!");
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt;
            List<IvObj> DataList = new List<IvObj>();
            List<string> StudentIDList = new List<string>();
            List<IvObj> IvObjList = new List<IvObj>();

            if (c.是否使用學年期)
            {
                //True就是使用學年期條件
                StringBuilder sb = new StringBuilder();
                sb.Append("select ref_student_id, SUM(hours) as SUM_hours ,school_year,semester from ");
                sb.Append(tool.TableName.ToLower() + " ");
                sb.Append(string.Format("where school_year={0} and semester={1} ", c.學年度, c.學期));
                sb.Append("GROUP BY ref_student_id,school_year,semester");

                dt = tool._Q.Select(sb.ToString());
            }
            else
            {
                //False就是統計學生所有資料
                StringBuilder sb = new StringBuilder();
                sb.Append("select ref_student_id, SUM(hours) as SUM_hours from ");
                sb.Append(tool.TableName.ToLower() + " ");
                sb.Append("GROUP BY ref_student_id");

                dt = tool._Q.Select(sb.ToString());
            }

            //無資料的搜尋
            if (!checkBoxX3.Checked)
            {
                #region 有資料

                foreach (DataRow row in dt.Rows)
                {
                    IvObj obj = new IvObj(row);
                    if (c.是否使用學年期)
                    {
                        obj.School_Year = "" + row["school_year"];
                        obj.Semester = "" + row["semester"];
                    }
                    IvObjList.Add(obj);

                    string studentid = "" + row["ref_student_id"];
                    if (!StudentIDList.Contains(studentid))
                    {
                        StudentIDList.Add(studentid);
                    }
                }

                List<StudentRecord> StudentList1 = Student.SelectByIDs(StudentIDList);
                List<string> ClassIDList = new List<string>();
                Dictionary<string, StudentRecord> StudentDic = new Dictionary<string, StudentRecord>();
                foreach (StudentRecord student in StudentList1)
                {
                    if (student.Status == StudentRecord.StudentStatus.一般 || student.Status == StudentRecord.StudentStatus.延修)
                    {
                        if (!StudentDic.ContainsKey(student.ID))
                        {
                            StudentDic.Add(student.ID, student);
                        }

                        if (!string.IsNullOrEmpty(student.RefClassID))
                        {
                            if (!ClassIDList.Contains(student.RefClassID))
                            {
                                ClassIDList.Add(student.RefClassID);
                            }
                        }
                    }
                }

                Dictionary<string, ClassRecord> ClassDic = new Dictionary<string, ClassRecord>();
                List<ClassRecord> ClassList = Class.SelectByIDs(ClassIDList);
                foreach (ClassRecord each in ClassList)
                {
                    if (!ClassDic.ContainsKey(each.ID))
                    {
                        ClassDic.Add(each.ID, each);
                    }
                }

                //填入學生物件
                List<IvObj> new_List = new List<IvObj>();
                foreach (IvObj each in IvObjList)
                {
                    if (StudentDic.ContainsKey(each.ref_student_id)) //有學生物件
                    {
                        new_List.Add(each);
                        each.student = StudentDic[each.ref_student_id];

                        if (!string.IsNullOrEmpty(each.student.RefClassID)) //該學生有班級
                        {
                            if (ClassDic.ContainsKey(each.student.RefClassID)) //班級清單內有該班級
                            {
                                each.classObj = ClassDic[each.student.RefClassID];
                            }
                        }
                    }
                }

                foreach (IvObj each in new_List)
                {
                    if (c.比較 == 比數.小於)
                    {
                        if (each.Hours < c.時數)
                        {
                            DataList.Add(each);
                        }
                    }
                    else if (c.比較 == 比數.大於等於)
                    {
                        if (each.Hours >= c.時數)
                        {
                            DataList.Add(each);
                        }
                    }
                }
                #endregion
            }
            else
            {

                #region 無資料

                foreach (DataRow row in dt.Rows)
                {
                    string studentid = "" + row["ref_student_id"];
                    if (!StudentIDList.Contains(studentid))
                    {
                        StudentIDList.Add(studentid);
                    }
                }

                StringBuilder sb1 = new StringBuilder();
                if (StudentIDList.Count > 0)
                {
                    sb1.AppendFormat("select id from student where status in(1,2) and id not in ('{0}')", string.Join("','", StudentIDList));
                }
                else
                {
                    //當學生ID為0,表示為所有學生資料
                    sb1.AppendFormat("select id from student where status in(1,2)");
                }

                DataTable dt2 = tool._Q.Select(sb1.ToString());
                List<string> list = new List<string>();
                foreach (DataRow row in dt2.Rows)
                {
                    string id = "" + row[0];
                    IvObj obj = new IvObj(id);
                    if (c.是否使用學年期)
                    {
                        obj.School_Year = "" + c.學年度;
                        obj.Semester = "" + c.學期;
                    }
                    IvObjList.Add(obj);

                    list.Add(id);
                }

                Dictionary<string, StudentRecord> StudentDic = new Dictionary<string, StudentRecord>();
                List<StudentRecord> StudentList1 = Student.SelectByIDs(list);
                List<string> ClassIDList = new List<string>();
                foreach (StudentRecord student in StudentList1)
                {
                    if (!StudentDic.ContainsKey(student.ID))
                    {
                        StudentDic.Add(student.ID, student);
                    }

                    if (!string.IsNullOrEmpty(student.RefClassID))
                    {
                        if (!ClassIDList.Contains(student.RefClassID))
                        {
                            ClassIDList.Add(student.RefClassID);
                        }
                    }
                }

                Dictionary<string, ClassRecord> ClassDic = new Dictionary<string, ClassRecord>();
                List<ClassRecord> ClassList = Class.SelectByIDs(ClassIDList);
                foreach (ClassRecord each in ClassList)
                {
                    if (!ClassDic.ContainsKey(each.ID))
                    {
                        ClassDic.Add(each.ID, each);
                    }
                }

                foreach (IvObj each in IvObjList)
                {
                    if (StudentDic.ContainsKey(each.ref_student_id))
                    {
                        each.student = StudentDic[each.ref_student_id];

                        if (!string.IsNullOrEmpty(each.student.RefClassID)) //該學生有班級
                        {
                            if (ClassDic.ContainsKey(each.student.RefClassID)) //班級清單內有該班級
                            {
                                each.classObj = ClassDic[each.student.RefClassID];
                            }
                        }
                    }
                }

                DataList.AddRange(IvObjList);

                #endregion

            }

            DataList.Sort(SortDataStudent);
            e.Result = DataList;
        }

        private int SortDataStudent(IvObj i1, IvObj i2)
        {
            StudentRecord sr1 = i1.student;
            ClassRecord cr1 = i1.classObj;
            #region string1
            string string1 = "";
            if (cr1 != null)
            {
                string1 += cr1.GradeYear.HasValue ? cr1.GradeYear.Value.ToString().PadLeft(1, '0') : "0";
                string1 += cr1.DisplayOrder.PadLeft(3, '0');
                string1 += cr1.Name.PadLeft(3, '0');
            }
            else
            {
                string1 += "0000000000";
            }
            string1 += sr1.SeatNo.HasValue ? sr1.SeatNo.Value.ToString().PadLeft(3, '0') : "000";
            string1 += sr1.Name.PadLeft(5, '0');
            #endregion

            StudentRecord sr2 = i2.student;
            ClassRecord cr2 = i2.classObj;
            #region string2
            string string2 = "";
            if (cr2 != null)
            {
                string2 += cr2.GradeYear.HasValue ? cr2.GradeYear.Value.ToString().PadLeft(1, '0') : "0";
                string2 += cr2.DisplayOrder.PadLeft(3, '0');
                string2 += cr2.Name.PadLeft(3, '0');
            }
            else
            {
                string2 += "0000000000";
            }
            string2 += sr2.SeatNo.HasValue ? sr2.SeatNo.Value.ToString().PadLeft(3, '0') : "000";
            string2 += sr2.Name.PadLeft(5, '0');
            #endregion

            return string1.CompareTo(string2);
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "學生服務時數查詢";
            btnSelecta.Enabled = true;
            if (e.Cancelled)
            {
                MsgBox.Show("資料取得已被中止");
            }
            else
            {
                if (e.Error == null)
                {
                    List<IvObj> DataList = (List<IvObj>)e.Result;
                    dataGridViewX1.AutoGenerateColumns = false;
                    dataGridViewX1.DataSource = DataList;
                    labelX5.Text = string.Format("查詢資料筆數：{0} 筆", DataList.Count);
                }
                else
                {
                    MsgBox.Show("發生錯誤:\n" + e.Error.Message);
                }
            }
        }

        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {
            labelX2.Enabled = checkBoxX4.Checked;
            integerInput1.Enabled = checkBoxX4.Checked;
            labelX3.Enabled = checkBoxX4.Checked;
            integerInput2.Enabled = checkBoxX4.Checked;
            colSchoolYear.Visible = checkBoxX4.Checked;
            colSemester.Visible = checkBoxX4.Checked;
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            decimal d;
            if (!decimal.TryParse(textBoxX1.Text, out d))
            {
                errorProvider1.SetError(textBoxX1, "輸入內容必須為數字!!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void 加入待處理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NowAddToTemp();
        }

        private void NowAddToTemp()
        {
            List<string> StudentIDList = new List<string>();

            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                IvObj obj = (IvObj)row.DataBoundItem;
                if (!StudentIDList.Contains(obj.ref_student_id))
                {
                    StudentIDList.Add(obj.ref_student_id);
                }
            }

            K12.Presentation.NLDPanels.Student.AddToTemp(StudentIDList);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 清空待處理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            K12.Presentation.NLDPanels.Student.RemoveFromTemp(K12.Presentation.NLDPanels.Student.TempSource);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "匯出學生服務時數查詢";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dataGridViewX1);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void dataGridViewX1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoubleClick();
        }

        private void DoubleClick()
        {
            //當使用者連點該Ron時
            DataGridViewRow row = dataGridViewX1.CurrentRow;
            IvObj obj = (IvObj)row.DataBoundItem;
            DetailFrom df = new DetailFrom(obj, c);
            df.ShowDialog();

            //變更畫面上的資料

            obj.Hours = df.NowDecimal;

        }

        private void 查看明細資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoubleClick();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked)
            {
                Point p1 = new Point(10, 12);
                Point p2 = new Point(214, 10);
                labelX1.Location = p1;
                textBoxX1.Location = p2;
            }
        }

        private void checkBoxX2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX2.Checked)
            {
                Point p1 = new Point(10, 42);
                Point p2 = new Point(214, 40);
                labelX1.Location = p1;
                textBoxX1.Location = p2;
            }
        }

        private void checkBoxX3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX3.Checked)
            {
                Point p1 = new Point(10, 72);
                Point p2 = new Point(214, 70);
                labelX1.Location = p1;
                textBoxX1.Location = p2;
            }

            textBoxX1.Visible = !checkBoxX3.Checked;

        }
    }

    public enum 比數 { 大於等於, 小於, 無資料 }

    public class Congig
    {
        public 比數 比較 { get; set; }
        public int 學年度 { get; set; }
        public int 學期 { get; set; }
        public decimal 時數 { get; set; }
        public bool 是否使用學年期 { get; set; }
    }
}
