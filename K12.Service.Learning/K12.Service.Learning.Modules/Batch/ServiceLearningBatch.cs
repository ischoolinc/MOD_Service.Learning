using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using K12.Data;
using FISCA.LogAgent;

namespace K12.Service.Learning.Modules
{
    public partial class ServiceLearningBatch : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        /// <summary>
        /// 取得Record or Insert
        /// </summary>
        AccessHelper _accesshelper = new AccessHelper();

        FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

        List<ServiceDataRow> DataRowList { get; set; }

        Dictionary<string, string> GradeYearDic { get; set; }

        服務學習大小 checkNow { get; set; }
        int 服務學習時數 { get; set; }

        bool DataIsChange = false;

        Dictionary<string, SLRecord> LogSLRDic { get; set; }

        Dictionary<string, StudentRecord> StudentDic { get; set; }

        public ServiceLearningBatch()
        {
            InitializeComponent();
        }

        private void ServiceLearningBatch_Load(object sender, EventArgs e)
        {
            //畫面鎖定後執行查詢

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            K12.Presentation.NLDPanels.Student.TempSourceChanged += new EventHandler(Student_TempSourceChanged);

            dtStartTime.Value = DateTime.Today.AddDays(-7);
            dtEntTime.Value = DateTime.Today;

            //取得目前系統內的年級清單
            //List<string> GradeList = GetGradeList();
            //GradeList.Sort();
            //cbGradeYear.Items.Clear();
            //cbGradeYear.Items.Add("");
            //cbGradeYear.Items.AddRange(GradeList.ToArray());
            //intHours.Value = 0;

            //畫面鎖定後執行查詢
            LockFrom = false;

            RunSelect();
        }

        /// <summary>
        /// 取得系統內年級清單
        /// </summary>
        //private List<string> GetGradeList()
        //{
        //    DataTable dt = _queryHelper.Select("select DISTINCT grade_year from class");
        //    List<string> list = new List<string>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        string grade_year = "" + row[0];
        //        if (string.IsNullOrEmpty(grade_year))
        //            continue;
        //        if (!list.Contains(grade_year))
        //        {
        //            list.Add(grade_year);
        //        }

        //    }
        //    return list;
        //}

        /// <summary>
        /// 執行查詢
        /// </summary>
        private void RunSelect()
        {
            if (errorProvider1.GetError(textBoxX1) == "")
            {
                if (!BGW.IsBusy)
                {
                    LockFrom = false; //鎖定畫面

                    ConfigByBatch cbb = new ConfigByBatch();
                    cbb.StartTime = dtStartTime.Value;
                    cbb.EndTime = dtEntTime.Value;
                    //cbb.GradeYear = cbGradeYear.Text.Trim();
                    //cbb.Hours = intHours.Value;
                    cbb.Reason = txtReason.Text.Trim();
                    cbb.Hours = decimal.Parse(textBoxX1.Text);

                    if (checkBoxX2.Checked)
                    {
                        cbb.checkNow = 服務學習大小.小於;
                    }
                    else if (checkBoxX3.Checked)
                    {
                        cbb.checkNow = 服務學習大小.等於;
                    }
                    else
                    {
                        cbb.checkNow = 服務學習大小.大於;
                    }

                    if (cbRegisterDate.Checked)
                        cbb.SelectDayType = false;

                    //if (chHours1.Checked)
                    //    cbb.type = CheckType.大於;
                    //else if (chHours2.Checked)
                    //    cbb.type = CheckType.等於;
                    //else if (chHours3.Checked)
                    //    cbb.type = CheckType.小於;



                    BGW.RunWorkerAsync(cbb);
                }
                else
                {
                    MsgBox.Show("系統忙碌中,請稍後再試...");
                }
            }
            else
            {
                MsgBox.Show("時數條件有誤請重新輸入!!");
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            LogSLRDic = new Dictionary<string, SLRecord>();

            ConfigByBatch cbb = (ConfigByBatch)e.Argument;

            #region 當年級有設定時,取得年級資料
            //GradeYearDic = new Dictionary<string, string>();
            //if (!string.IsNullOrEmpty(cbb.GradeYear))
            //{
            //    DataTable dt = _queryHelper.Select("select student.id,class.grade_year from student join class on class.id=student.ref_class_id");
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        string studentID = "" + row[0];
            //        string grade_year = "" + row[1];
            //        if (!GradeYearDic.ContainsKey(studentID))
            //        {
            //            GradeYearDic.Add(studentID, grade_year);
            //        }
            //    }
            //}
            #endregion

            StringBuilder accessString = new StringBuilder();

            if (cbb.SelectDayType)
            {
                accessString.Append(string.Format("occur_date>={0} and occur_date<={1}", cbb.StartTime.ToShortDateString(), cbb.EndTime.ToShortDateString()));
            }
            else
            {
                accessString.Append(string.Format("register_date>={0} and register_date<={1}", cbb.StartTime.ToShortDateString(), cbb.EndTime.ToShortDateString()));
            }

            //取得資料
            List<SLRecord> SelectList = _accesshelper.Select<SLRecord>(accessString.ToString());

            //篩選條件後資料
            List<SLRecord> SLRecordList = GetFilterList(SelectList, cbb);
            foreach (SLRecord each in SLRecordList)
            {
                if (!LogSLRDic.ContainsKey(each.UID))
                {
                    LogSLRDic.Add(each.UID, each.CopyExtension());
                }
            }

            //取得學生基本資料
            StudentDic = GetStudentRecord(SLRecordList);

            //建立DataGridView DataRow
            List<ServiceDataRow> newDataRowList = new List<ServiceDataRow>();
            foreach (SLRecord each in SLRecordList)
            {
                if (StudentDic.ContainsKey(each.RefStudentID))
                {
                    ServiceDataRow row = new ServiceDataRow(StudentDic[each.RefStudentID], each);
                    row.PropertyChanged += new PropertyChangedEventHandler(row_PropertyChanged);
                    newDataRowList.Add(row);
                }
            }

            Class.SelectAll();
            newDataRowList.Sort(SortByClassName);

            e.Result = newDataRowList;
        }

        private int SortByClassName(ServiceDataRow row1, ServiceDataRow row2)
        {
            StudentRecord sr1 = row1._student;
            StudentRecord sr2 = row2._student;

            string studentSort1 = "";
            string studentSort2 = "";

            #region 年級
            if (!string.IsNullOrEmpty(sr1.RefClassID))
            {
                if (sr1.Class.GradeYear.HasValue)
                {
                    studentSort1 += sr1.Class.GradeYear.Value.ToString().PadLeft(1, '0');
                }
                else
                {
                    studentSort1 += "0";
                }
            }
            else
            {
                studentSort1 += "0";
            }

            if (!string.IsNullOrEmpty(sr2.RefClassID))
            {
                if (sr2.Class.GradeYear.HasValue)
                {
                    studentSort2 += sr2.Class.GradeYear.Value.ToString().PadLeft(1, '0');
                }
                else
                {
                    studentSort2 += "0";
                }
            }
            else
            {
                studentSort2 += "0";
            }
            #endregion

            #region 班級序號

            if (!string.IsNullOrEmpty(sr1.RefClassID))
            {
                studentSort1 += sr1.Class.DisplayOrder.PadLeft(3, '0');
            }
            else
            {
                studentSort1 += "000";
            }

            if (!string.IsNullOrEmpty(sr2.RefClassID))
            {
                studentSort2 += sr2.Class.DisplayOrder.PadLeft(3, '0');
            }
            else
            {
                studentSort2 += "000";
            }

            #endregion

            #region 班級

            if (!string.IsNullOrEmpty(sr1.RefClassID))
            {
                studentSort1 = sr1.Class.Name.PadLeft(6, '0');
            }
            else
            {
                studentSort1 = "000000";
            }

            if (!string.IsNullOrEmpty(sr2.RefClassID))
            {
                studentSort2 = sr2.Class.Name.PadLeft(6, '0');
            }
            else
            {
                studentSort2 = "000000";
            }
            #endregion

            #region 座號

            if (sr1.SeatNo.HasValue)
                studentSort1 += sr1.SeatNo.Value.ToString().PadLeft(3, '0');
            else
                studentSort1 += "000";

            if (sr2.SeatNo.HasValue)
                studentSort2 += sr2.SeatNo.Value.ToString().PadLeft(3, '0');
            else
                studentSort2 += "000";
            #endregion

            //姓名
            studentSort1 += sr1.Name.PadLeft(10, '0');
            studentSort2 += sr2.Name.PadLeft(10, '0');

            return studentSort1.CompareTo(studentSort2);
        }

        void row_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Text = "服務學習批次修改(資料已修改)";
            DataIsChange = true;
        }

        /// <summary>
        /// 透過服務學習資料,取得學生基本資料
        /// </summary>
        private Dictionary<string, StudentRecord> GetStudentRecord(List<SLRecord> SLRecordList)
        {
            Dictionary<string, StudentRecord> dic = new Dictionary<string, StudentRecord>();
            List<string> StudentIDList = new List<string>();

            foreach (SLRecord each in SLRecordList)
            {
                if (!StudentIDList.Contains(each.RefStudentID))
                {
                    StudentIDList.Add(each.RefStudentID);
                }
            }

            foreach (StudentRecord each in Student.SelectByIDs(StudentIDList))
            {
                if (!dic.ContainsKey(each.ID))
                {
                    dic.Add(each.ID, each);
                }
            }

            return dic;
        }

        private List<SLRecord> GetFilterList(List<SLRecord> SelectList, ConfigByBatch cbb)
        {
            List<SLRecord> list = new List<SLRecord>();
            foreach (SLRecord each in SelectList)
            {
                #region 事由/主辦單位
                bool 事由與主辦單位 = false;
                string Reason = cbb.Reason.Trim();
                if (!string.IsNullOrEmpty(Reason))
                {
                    if (each.Reason.Contains(Reason) || each.Organizers.Contains(Reason))
                    {
                        事由與主辦單位 = true;
                    }
                }
                else
                {
                    事由與主辦單位 = true;
                }
                #endregion

                #region 時數大小(註解)
                bool 時數大小 = false;
                if (cbb.checkNow == 服務學習大小.小於)
                {
                    if (each.Hours < cbb.Hours)
                    {
                        時數大小 = true;
                    }
                }
                else if (cbb.checkNow == 服務學習大小.等於)
                {
                    if (each.Hours == cbb.Hours)
                    {
                        時數大小 = true;
                    }
                }
                else
                {
                    if (each.Hours > cbb.Hours)
                    {
                        時數大小 = true;
                    }
                }
                #endregion

                if (事由與主辦單位 && 時數大小)
                {
                    list.Add(each);
                }
            }
            return list;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LockFrom = true; //解除鎖定

            if (e.Cancelled)
            {
                MsgBox.Show("背景作業已取消...");
            }
            else
            {
                if (e.Error == null)
                {
                    List<ServiceDataRow> newDataRowList = (List<ServiceDataRow>)e.Result;
                    DataIsChange = false;
                    //加入資料Row
                    dataGridViewX1.AutoGenerateColumns = false;
                    dataGridViewX1.DataSource = new BindingList<ServiceDataRow>(newDataRowList);
                    DataRowList = newDataRowList;
                    dataGridViewX1_SelectionChanged(null, null);
                    this.Text = "服務學習批次修改";
                }
                else
                {
                    MsgBox.Show("取得資料發生錯誤...\n" + e.Error.Message);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (DataIsChange)
            {
                DialogResult dr = MsgBox.Show("是否重新整理?", "畫面資料已修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == System.Windows.Forms.DialogResult.No)
                    return;
            }

            RunSelect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //儲存畫面資料與修改
            List<SLRecord> UpDataList = GetUpDataList();

            if (UpDataList.Count > 0)
            {
                try
                {
                    _accesshelper.UpdateValues(UpDataList);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("資料更新發生錯誤!!\n" + ex.Message);
                    return;
                }

                #region Log

                StringBuilder sb = new StringBuilder();
                foreach (SLRecord each in UpDataList)
                {
                    if (LogSLRDic.ContainsKey(each.UID))
                    {
                        SLRecord slrlog = LogSLRDic[each.UID];

                        sb.Append(GetLogString(slrlog, each));
                    }
                }

                ApplicationLog.Log("服務學習批次修改", "更新", sb.ToString());

                #endregion

                MsgBox.Show("儲存成功!!");
                RunSelect();
            }
            else
            {
                MsgBox.Show("資料未被修改!!");
            }
        }

        private string GetLogString(SLRecord slrlog, SLRecord each)
        {
            StringBuilder message = new StringBuilder();

            if (StudentDic.ContainsKey(slrlog.RefStudentID))
            {
                StudentRecord sr = StudentDic[slrlog.RefStudentID];

                message.AppendLine(string.Format("學號「" + sr.StudentNumber + "」學生「" + sr.Name + "」服務學習資料已修改："));

                if (!string.IsNullOrEmpty(C_Change("學年度", slrlog.SchoolYear.ToString(), each.SchoolYear.ToString())))
                    message.AppendLine(C_Change("學年度", slrlog.SchoolYear.ToString(), each.SchoolYear.ToString()));
                if (!string.IsNullOrEmpty(C_Change("學期", slrlog.Semester.ToString(), each.Semester.ToString())))
                    message.AppendLine(C_Change("學期", slrlog.Semester.ToString(), each.Semester.ToString()));
                if (!string.IsNullOrEmpty(C_Change("發生日期", slrlog.OccurDate.ToShortDateString(), each.OccurDate.ToShortDateString())))
                    message.AppendLine(C_Change("發生日期", slrlog.OccurDate.ToShortDateString(), each.OccurDate.ToShortDateString()));
                if (!string.IsNullOrEmpty(C_Change("時數", slrlog.Hours.ToString(), each.Hours.ToString())))
                    message.AppendLine(C_Change("時數", slrlog.Hours.ToString(), each.Hours.ToString()));
                if (!string.IsNullOrEmpty(C_Change("事由", slrlog.Reason, each.Reason)))
                    message.AppendLine(C_Change("事由", slrlog.Reason, each.Reason));
                if (!string.IsNullOrEmpty(C_Change("校內校外", slrlog.InternalOrExternal, each.InternalOrExternal)))
                    message.AppendLine(C_Change("校內校外", slrlog.InternalOrExternal, each.InternalOrExternal));
                if (!string.IsNullOrEmpty(C_Change("主辦單位", slrlog.Organizers, each.Organizers)))
                    message.AppendLine(C_Change("主辦單位", slrlog.Organizers, each.Organizers));
                if (!string.IsNullOrEmpty(C_Change("備註", slrlog.Remark, each.Remark)))
                    message.AppendLine(C_Change("備註", slrlog.Remark, each.Remark));
                if (!string.IsNullOrEmpty(C_Change("登錄日期", slrlog.RegisterDate.ToShortDateString(), each.RegisterDate.ToShortDateString())))
                    message.AppendLine(C_Change("登錄日期", slrlog.RegisterDate.ToShortDateString(), each.RegisterDate.ToShortDateString()));

                message.AppendLine("");
            }


            return message.ToString();


        }

        /// <summary>
        /// 資料是否不相等
        /// True:資料不相同/False:資料相同
        /// </summary>
        private string C_Change(string p1, string p2, string p3)
        {
            string messageDef = "{0}由「{1}」調整為「{2}」";
            if (p2 != p3)
            {
                return string.Format(messageDef, p1, p2, p3);
            }
            else
            {
                return string.Empty;
            }
        }

        private List<SLRecord> GetUpDataList()
        {
            List<SLRecord> list = new List<SLRecord>();
            foreach (DataGridViewRow row in dataGridViewX1.Rows)
            {
                ServiceDataRow sdr = (ServiceDataRow)row.DataBoundItem;

                if (!sdr.IsChange)
                    continue;

                list.Add(sdr._slr);
            }
            return list;
        }

        /// <summary>
        /// 匯出服務學習記錄
        /// </summary>
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "匯出服務學習時數記錄";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dataGridViewX1);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }

        private void 加入待處理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToTemp();
        }

        private void 自畫面上移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                ServiceDataRow sdr = (ServiceDataRow)row.DataBoundItem;

                dataGridViewX1.Rows.Remove(row);
                DataRowList.Remove(sdr);
            }
        }

        private void 刪除選擇資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MsgBox.Show("是否刪除選擇的" + dataGridViewX1.SelectedRows.Count + "筆資料?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                List<SLRecord> list = new List<SLRecord>();

                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    ServiceDataRow sdr = (ServiceDataRow)row.DataBoundItem;

                    list.Add(sdr._slr);

                    if (StudentDic.ContainsKey(sdr._slr.RefStudentID))
                    {
                        StudentRecord sr = StudentDic[sdr._slr.RefStudentID];
                        sb.AppendLine(string.Format("學生「{0}」日期「{1}」服務學習資料已刪除", sr.Name, sdr._slr.OccurDate.ToShortDateString()));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("學生「{0}」日期「{1}」服務學習資料已刪除", sdr.StudentID, sdr._slr.OccurDate.ToShortDateString()));

                    }


                }
                ApplicationLog.Log("服務學習批次修改", "刪除", sb.ToString() + "\n\n共刪除" + list.Count + "筆資料");
                //刪除
                _accesshelper.DeletedValues(list);
                //刪除資料後,再查一次即可
                RunSelect();
            }
            else
            {
                MsgBox.Show("已中止刪除動作!");
            }
        }

        #region 其它

        /// <summary>
        /// 加入待處理
        /// </summary>
        private void btnAddTemp_Click(object sender, EventArgs e)
        {
            AddToTemp();
        }

        /// <summary>
        /// 將目前選擇的Row List,學生加入待處理
        /// </summary>
        private void AddToTemp()
        {
            List<string> list = new List<string>();
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                ServiceDataRow sdr = (ServiceDataRow)row.DataBoundItem;
                if (sdr != null)
                {
                    if (!list.Contains(sdr.StudentID))
                    {
                        list.Add(sdr.StudentID);
                    }
                }
            }

            K12.Presentation.NLDPanels.Student.AddToTemp(list);
        }

        /// <summary>
        /// 鎖定畫面
        /// </summary>
        bool LockFrom
        {
            set
            {
                btnSelect.Enabled = value;
                dtStartTime.Enabled = value;
                dtEntTime.Enabled = value;
                txtReason.Enabled = value;
                //cbGradeYear.Enabled = value;
                //intHours.Enabled = value;

                dataGridViewX1.Enabled = value;
                btnSave.Enabled = value;
                btnExit.Enabled = value;
                btnExport.Enabled = value;
                btnAddTemp.Enabled = value;

                if (value)
                {
                    this.Text = "服務學習批次修改";
                }
                else
                {
                    this.Text = "服務學習批次修改(處理中...)";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void 批次修改事由ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeReasonForm ctf = new ChangeReasonForm("事由", sdr.Reason);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.Reason = ctf.ChangeText;
                }
            }
        }

        private void 批次修改主辦單位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeOrganizersForm ctf = new ChangeOrganizersForm("主辦單位", sdr.Organizers);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.Organizers = ctf.ChangeText;
                }
            }
        }

        private void 批次修改備註ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeTextForm ctf = new ChangeTextForm("備註", sdr.Remark);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.Remark = ctf.ChangeText;
                }
            }
        }

        private void 批次修改時數ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeIntForm ctf = new ChangeIntForm("時數", sdr.Hours);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.Hours = ctf.ChangeInt;
                }
            }
        }

        private void 批次修改發生日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeDateTimeForm ctf = new ChangeDateTimeForm("發生日期", sdr.OccurDate);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.OccurDate = ctf.ChangeTime.ToShortDateString();
                }
            }
        }

        private void 批次修改學年度學期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeSchoolYearSemester ctf = new ChangeSchoolYearSemester("學年度/學期", sdr.SchoolYear, sdr.Semester);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.SchoolYear = ctf.ChangeSchoolYear;
                    sdr.Semester = ctf.ChangeSemester;
                }
            }
        }

        private void ServiceLearningBatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataIsChange)
            {
                DialogResult dr = MsgBox.Show("是否關閉畫面?", "畫面資料已修改", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (dr == System.Windows.Forms.DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void 批次修改所有資料toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeAllDataForm ctf = new ChangeAllDataForm("所有", sdr._slr);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;

                    sdr.SchoolYear = ctf.學年度;
                    sdr.Semester = ctf.學期;
                    sdr.OccurDate = ctf.日期;
                    sdr.Reason = ctf.事由;
                    sdr.Hours = ctf.時數;
                    sdr.Organizers = ctf.主辦單位;
                    sdr.InternalAndExternal = ctf.校內校外;
                    sdr.Remark = ctf.備註;
                }
            }
        }

        void Student_TempSourceChanged(object sender, EventArgs e)
        {
            labelX2.Text = string.Format("待處理學生：共{0}人", K12.Presentation.NLDPanels.Student.TempSource.Count);
        }

        private void 清空學生待處理toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            K12.Presentation.NLDPanels.Student.RemoveFromTemp(K12.Presentation.NLDPanels.Student.TempSource);
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            labelX1.Text = string.Format("已選/總數：{0}/{1}", dataGridViewX1.SelectedRows.Count, dataGridViewX1.Rows.Count);
           

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            decimal dm;
            if (decimal.TryParse(textBoxX1.Text, out dm))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(textBoxX1, "輸入資料必須為數字!!");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ServiceDataRow sdr = (ServiceDataRow)dataGridViewX1.CurrentRow.DataBoundItem;
            ChangeInorOutForm ctf = new ChangeInorOutForm("校內校外", sdr.InternalAndExternal);
            DialogResult dr = ctf.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
                {
                    sdr = (ServiceDataRow)row.DataBoundItem;
                    sdr.InternalAndExternal = ctf.ChangeText;
                }
            }
        }

        //private void dataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.ColumnIndex == ColOccurDate.Index)
        //    {
        //        if (IsSortOccurDate)
        //            IsSortOccurDate = false;
        //        else
        //            IsSortOccurDate = true;

        //        DataRowList.Sort(SortByOccurDate);
        //    }
        //}

        //bool IsSortOccurDate = false;
        //private int SortByOccurDate(ServiceDataRow row1, ServiceDataRow row2)
        //{
        //    if (IsSortOccurDate)
        //        return row1._slr.OccurDate.CompareTo(row2._slr.OccurDate);
        //    else
        //        return row2._slr.OccurDate.CompareTo(row1._slr.OccurDate);
        //}
    }

    enum 服務學習大小 { 大於, 小於, 等於, }
}
