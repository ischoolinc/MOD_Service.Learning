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
//using K12.Service.Learning.Modules;
//using FISCA.LogAgent;

namespace K12.Service.Learning.CreationItems
{
    public partial class CreationItem : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        /// <summary>
        /// 取得Record or Insert
        /// </summary>
        
        List<CreationItemsRecord> DataRowList { get; set; }
        class filter {
            public string SchoolYear { get; set; }
            public string Semester { get; set; }
            public string Organizers { get; set; }
        }
        public CreationItem()
        {
            InitializeComponent();
        }
        private void ServiceLearningBatch_Load(object sender, EventArgs e)
        {
            //畫面鎖定後執行查詢
            //_A.Select<CreationItemsRecord>();
            DataTable dt = tool._Q.Select("select distinct school_year,semester,organizers from $k12.service.learning.creationitemsrecord order by school_year desc,semester desc,organizers");
            foreach (DataRow row in dt.Rows)
            {
                if (!filterSchoolYear.Items.Contains(""+row[0]))
                    filterSchoolYear.Items.Add(""+row[0]);
                if (!filterSemester.Items.Contains(""+row[1]))
                    filterSemester.Items.Add("" + row[1]);
                if (!filterOrganizers.Items.Contains("" + row[2]))
                    filterOrganizers.Items.Add("" + row[2]);
            }
            filterSchoolYear.Text = School.DefaultSchoolYear;
            filterSemester.Text = School.DefaultSemester;
            filterSchoolYear.TextChanged += filter_TextChanged;
            filterSemester.TextChanged += filter_TextChanged;
            filterOrganizers.TextChanged += filter_TextChanged;
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            //LockFrom = false;
            RunSelect();
        }

        void filter_TextChanged(object sender, EventArgs e)
        {
            RunSelect();
        }
        /// <summary>
        /// 執行查詢
        /// </summary>
        private void RunSelect()
        {
            int tmpSchoolYear ,tmpSemester ;
            bool bool1 = int.TryParse(filterSchoolYear.Text,out tmpSchoolYear);
            bool bool2 = int.TryParse(filterSemester.Text,out tmpSemester);
            if (bool1 && bool2 )
            {
                if (!BGW.IsBusy)
                {
                    //LockFrom = false; //鎖定畫面
                    BGW.RunWorkerAsync(new filter() {
                        SchoolYear=filterSchoolYear.Text,
                        Semester=filterSemester.Text,
                        Organizers = filterOrganizers.Text,
                        }
                    );
                }
                else
                {
                    //MsgBox.Show("系統忙碌中,請稍後再試...");
                }
            }
            else
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.DataSource = new BindingList<CreationItemsRecord>();
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            filter filter = (filter)e.Argument;
            //取得資料
            List<string> where = new List<string>();
            where.Add("school_year =" + filter.SchoolYear);
            where.Add("semester =" + filter.Semester);
            if (!string.IsNullOrWhiteSpace(filter.Organizers))
                where.Add("organizers = '" + filter.Organizers + "'");
            List<CreationItemsRecord> SelectList = tool._A.Select<CreationItemsRecord>(string.Join(" and ",where));
            e.Result = SelectList;
        }
        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LockFrom = true; //解除鎖定
            if (e.Cancelled)
            {
                MsgBox.Show("背景作業已取消...");
            }
            else if (e.Error != null)
            {
                MsgBox.Show("取得資料發生錯誤...\n" + e.Error.Message);
            }
            else if ( e.Result == null )
            {
                //Do Nothing
            }
            else
            {
                List<CreationItemsRecord> newDataRowList = (List<CreationItemsRecord>)e.Result;
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.DataSource = new BindingList<CreationItemsRecord>(newDataRowList);
                DataRowList = newDataRowList;
            }
        }
        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            int tmp_count = dataGridViewX1.SelectedRows.Count ;
            btnEdit.Enabled = tmp_count == 1;
            btnAuthorized.Enabled = tmp_count == 1;
            btnApproved.Enabled = tmp_count == 1;
            contextMenuStrip1.Enabled = tmp_count > 0;
        }
        /// <summary>
        /// 鎖定畫面
        /// </summary>
        bool LockFrom
        {
            set
            {
                btnNew.Enabled = value;
                btnEdit.Enabled = value;
                filterSchoolYear.Enabled = value;
                filterSemester.Enabled = value;
                btnAuthorized.Enabled = value;
                btnApproved.Enabled = value;
                dataGridViewX1.Enabled = value;
                btnExit.Enabled = value;
                contextMenuStrip1.Enabled = value;
                if (value)
                {
                    this.Text = "服務學習線上開設";
                }
                else
                {
                    this.Text = "服務學習線上開設(處理中...)";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 列印點名單ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                List<CreationItemsRecord> lci = new List<CreationItemsRecord>();
                foreach (DataGridViewRow item in dataGridViewX1.SelectedRows)
                {
                    lci.Add(DataRowList[item.Index]);
                }
                new RollSheet(lci).ShowDialog();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Item it = new Item(new CreationItemsRecord()
            {
                RegistStartTime = DateTime.Now,
                RegistEndTime = DateTime.Now,
                SchoolYear = int.Parse(filterSchoolYear.Text),
                Semester = int.Parse(filterSemester.Text),
                Organizers = filterOrganizers.Text
            }, filterOrganizers.Items);
            if (it.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                it._cir.CreateBy = FISCA.Authentication.DSAServices.UserAccount;
                it._cir.Save();
                //if (it._cir.SchoolYear == int.Parse(filterSchoolYear.Text) && it._cir.Semester == int.Parse(filterSemester.Text) )
                //    DataRowList.Add(it._cir);
                ApplicationLog.Log("服務學習線上開設", "新增項目", "新增一筆\n學年度:" + it._cir.SchoolYear + ",學期:" + it._cir.Semester + ",日期:" + it._cir.OccurDate + ",事由:" + it._cir.Reason + ",時數:" + it._cir.ExpectedHours + ",主辦單位:" + it._cir.Organizers + ",備註:" + it._cir.Remark);
                RunSelect();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count != 1)
                return;

            Item it = new Item(DataRowList[dataGridViewX1.SelectedRows[0].Index], filterOrganizers.Items);
            string log_before  = "原 學年度:" + it._cir.SchoolYear + ",學期:" + it._cir.Semester + ",日期:" + it._cir.OccurDate + ",事由:" + it._cir.Reason + ",時數:" + it._cir.ExpectedHours + ",主辦單位:" + it._cir.Organizers + ",備註:" + it._cir.Remark;
            if (it.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                it._cir.Save();
                if (it._cir.SchoolYear != int.Parse(filterSchoolYear.Text) || it._cir.Semester != int.Parse(filterSemester.Text))
                {
                    dataGridViewX1.Rows.RemoveAt(dataGridViewX1.SelectedRows[0].Index);
                    DataRowList.Remove(it._cir);
                }
                ApplicationLog.Log("服務學習線上開設", "修改項目", "修改一筆\n"+log_before
                    +"\n後 學年度:" + it._cir.SchoolYear + ",學期:" + it._cir.Semester + ",日期:" + it._cir.OccurDate + ",事由:" + it._cir.Reason + ",時數:" + it._cir.ExpectedHours + ",主辦單位:" + it._cir.Organizers + ",備註:" + it._cir.Remark);
                //RunSelect();
            }
        }

        private void btnAuthorized_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count != 1)
                return;

            AuthorizeForm it = new AuthorizeForm(DataRowList[dataGridViewX1.SelectedRows[0].Index]);
            if (it.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                it._cir.IsAuthorized = true;
                it._cir.AuthorizedBy = FISCA.Authentication.DSAServices.UserAccount;
                it._cir.AuthorizedAt = DateTime.Now;
                it._cir.Save();
                //RunSelect();
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count != 1)
                return;
            ApprovedForm it = new ApprovedForm(DataRowList[dataGridViewX1.SelectedRows[0].Index]);
            if (it.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                it._cir.IsApproved = true;
                it._cir.ApprovedBy = FISCA.Authentication.DSAServices.UserAccount;
                it._cir.ApprovedAt = DateTime.Now;
                it._cir.Save();
                //RunSelect();
            }
        }
        
    }
}
