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
using System.Xml.Linq;
using K12.Service.Learning.Modules;

namespace K12.Service.Learning.CreationItems
{
    public partial class ApprovedForm : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        public List<ServiceDataRow> DataRowList { get; set; }
        
        bool DataIsChange;
        public CreationItemsRecord _cir;
        public ApprovedForm(CreationItemsRecord cir)
        {
            InitializeComponent();
            _cir = cir;
        }

        private void ServiceLearningBatch_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            RunSelect();
        }
        private void RunSelect()
        {
            if (!BGW.IsBusy)
            {
                BGW.RunWorkerAsync();
            }
            else
            {
                MsgBox.Show("系統忙碌中,請稍後再試...");
            }
        }
        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> lsid = new List<string>();
             List<SLRecord> SelectList = new List<SLRecord>();
            //取得資料
            if (_cir.IsApproved)
            {
                XElement xe = _cir.ApprovedDetail;
                foreach (XElement item in xe.Elements("SLRecord"))
                {
                    lsid.Add(item.Element("RefStudentID").Value);
                    SelectList.Add(new SLRecord()
                    {
                        RefStudentID = item.Element("RefStudentID").Value,
                        SchoolYear = int.Parse(item.Element("SchoolYear").Value),
                        Semester = int.Parse(item.Element("Semester").Value),
                        OccurDate = DateTime.Parse(item.Element("OccurDate").Value),
                        Reason = item.Element("Reason").Value,
                        Hours = decimal.Parse(item.Element("Hours").Value),
                        Organizers = item.Element("Organizers").Value,
                        RegisterDate = DateTime.Parse(item.Element("RegisterDate").Value),
                        Remark = item.Element("Remark").Value,
                    });
                }
            }
            else
            {
                List<string> where = new List<string>();
                where.Add("ref_creationitemsrecord_id = '" + _cir.UID + "'");
                where.Add("can_participate = true");
                List<CreationItemsParticipateRecord> lcipr = tool._A.Select<CreationItemsParticipateRecord>(string.Join(" and ", where));
                
                foreach (CreationItemsParticipateRecord item in lcipr)
                {
                    lsid.Add(item.RefStudentId);
                    SelectList.Add(new SLRecord()
                    {
                        RefStudentID = item.RefStudentId,
                        SchoolYear = _cir.SchoolYear,
                        Semester = _cir.Semester,
                        OccurDate = _cir.OccurDate,
                        Reason = _cir.Reason,
                        Hours = decimal.Parse("" + _cir.ExpectedHours),
                        Organizers = _cir.Organizers,
                        RegisterDate = DateTime.Now,
                        Remark = _cir.Remark,
                    });
                }
            }
            Dictionary<string, StudentRecord> ds = K12.Data.Student.SelectByIDs(lsid).ToDictionary(x => x.ID, x => x);

            //取得學生基本資料

            //建立DataGridView DataRow
            List<ServiceDataRow> newDataRowList = new List<ServiceDataRow>();
            foreach (SLRecord each in SelectList)
            {
                if (ds.ContainsKey(each.RefStudentID))
                {
                    ServiceDataRow row = new ServiceDataRow(ds[each.RefStudentID], each);
                    row.PropertyChanged += new PropertyChangedEventHandler(row_PropertyChanged);
                    newDataRowList.Add(row);
                }
            }

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
            DataIsChange = true;
        }
        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MsgBox.Show("背景作業已取消...");
            }
            else if (e.Error != null)
            {
                MsgBox.Show("取得資料發生錯誤...\n" + e.Error.Message);
            }
            else if (e.Result == null)
            {
                //Do Nothing
            }
            else
            {
                List<ServiceDataRow> newDataRowList = (List<ServiceDataRow>)e.Result;
                DataIsChange = false;
                //加入資料Row
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.DataSource = new BindingList<ServiceDataRow>(newDataRowList);
                DataRowList = newDataRowList;
                dataGridViewX1_SelectionChanged(null, null);
                if (_cir.IsApproved)
                {
                    contextMenuStrip1.Enabled = false;
                    btnSave.Enabled = false;
                }
            }
        }
        private static List<SLRecord> takeoutSLRecordFormDataRow(IEnumerable<ServiceDataRow> esdr)
        {
            List<SLRecord> lslr = new List<SLRecord>();
            foreach (ServiceDataRow item in esdr)
            {
                lslr.Add(item._slr);   
            }
            return lslr;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = _cir.CreateBy != FISCA.Authentication.DSAServices.UserAccount ? "注意:您並非此項目的開設者" : "";
            if (MessageBox.Show("你是否要進行此操作? (儲存後無法修改)\n" + msg, "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //&& DataRowList.Count > 0)
            {
                List<string> log = new List<string>();
                List<SLRecord> lslr = new List<SLRecord>();
                try
                {
                    lslr = takeoutSLRecordFormDataRow(DataRowList);
                    tool._A.InsertValues(lslr);
                    XElement xe = _cir.ApprovedDetail;
                    int i = 1;
                    foreach (ServiceDataRow sdr in DataRowList)
                    {
                        SLRecord item = sdr._slr ;
                        XElement tmpxe = new XElement("SLRecord");
                        tmpxe.Add(new XElement("RefStudentID", item.RefStudentID));
                        tmpxe.Add(new XElement("SchoolYear", item.SchoolYear));
                        tmpxe.Add(new XElement("Semester", item.Semester));
                        tmpxe.Add(new XElement("OccurDate", item.OccurDate));
                        tmpxe.Add(new XElement("Reason", item.Reason));
                        tmpxe.Add(new XElement("Hours", item.Hours));
                        tmpxe.Add(new XElement("Organizers", item.Organizers));
                        tmpxe.Add(new XElement("RegisterDate", item.RegisterDate));
                        tmpxe.Add(new XElement("Remark", item.Remark));
                        xe.Add(tmpxe);
                        log.Add("" + i + "：學生系統編號:" + sdr.StudentID + ",學生姓名:" + sdr.StudentName + ",學號:" + sdr.StudentNumber + ",學年度:" + item.SchoolYear + ",學期:" + item.Semester + ",服務日期:" + item.OccurDate + ",服務事由:" + item.Reason + ",時數:" + item.Hours + ",主辦單位:" + item.Organizers + ",備註:" + item.Remark);
                            i++;
                    }
                    _cir.ApprovedDetail = new XElement("這不會被用到");
                    _cir.Save();
                }
                catch (Exception ex)
                {
                    MsgBox.Show("資料更新發生錯誤!!\n" + ex.Message);
                    return;
                }
                ApplicationLog.Log("服務學習線上開設", "登錄作業", "服務學習記錄\n已新增" + lslr.Count + "筆資料\n"+string.Join("\n",log));
                MsgBox.Show("儲存成功!!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void 自畫面上移除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                ServiceDataRow sdr = (ServiceDataRow)row.DataBoundItem;
                DataRowList.Remove(sdr);
                //dataGridViewX1.Rows.Remove(row);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你是否要離開?", "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

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
                    sdr.Remark = ctf.備註;
                }
            }
        }
        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            labelX1.Text = string.Format("已選/總數：{0}/{1}", dataGridViewX1.SelectedRows.Count, dataGridViewX1.Rows.Count);
        }

    }
}
