using FISCA.Presentation.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using K12.Data;
using FISCA.LogAgent;
namespace K12.Service.Learning.CreationItems
{
    public partial class AuthorizeForm : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();
        public CreationItemsRecord _cir;
        private List<CreationItemsParticipateRecord> lcipr;
        class filter {
            public string ref_creationitemsrecord_id { get; set; }
        }
        public AuthorizeForm(CreationItemsRecord cir)
        {
            InitializeComponent();
            _cir = cir;
        }
        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            //LockFrom = false;
            RunSelect();
        }
        private void RunSelect()
        {
            if (!BGW.IsBusy)
            {
                //LockFrom = false; //鎖定畫面
                BGW.RunWorkerAsync(new filter()
                {
                    ref_creationitemsrecord_id = _cir.UID 
                }
                );
            }
            else
            {
                MsgBox.Show("系統忙碌中,請稍後再試...");
            }
        }
        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            filter filter = (filter)e.Argument;
            //取得資料
            List<string> where = new List<string>();
            where.Add("ref_creationitemsrecord_id = '" + filter.ref_creationitemsrecord_id + "'");
            //tool._A.Select<CreationItemsParticipateRecord>();
            List<CreationItemsParticipateRecord> lr = tool._A.Select<CreationItemsParticipateRecord>(string.Join(" and ", where));
            e.Result = lr;
        }
        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //LockFrom = true; //解除鎖定
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
                //dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.Rows.Clear();
                //dataGridViewX1.Rows.Add(
                lcipr = (List<CreationItemsParticipateRecord>)e.Result;
                DataGridViewRow row;
                List<string> lsid = new List<string>();
                foreach (CreationItemsParticipateRecord item in lcipr)
                {
                    lsid.Add(item.RefStudentId);
                }
                if (lsid.Count > 0)
                {
                    Dictionary<string, StudentRecord> ds = K12.Data.Student.SelectByIDs(lsid).ToDictionary(x => x.ID, x => x);
                    foreach (CreationItemsParticipateRecord item in lcipr)
                    {
                        row = new DataGridViewRow();
                        row.CreateCells(dataGridViewX1);
                        row.Cells[0].Value = "" + ds[item.RefStudentId].Class.GradeYear;
                        row.Cells[1].Value = "" + ds[item.RefStudentId].Class.Name;
                        row.Cells[2].Value = "" + ds[item.RefStudentId].SeatNo;
                        row.Cells[3].Value = "" + ds[item.RefStudentId].Name;
                        row.Cells[4].Value = "" + ds[item.RefStudentId].StudentNumber;
                        row.Cells[5].Value = item.CanParticipate?"True":"false";
                        row.Tag = item;
                        dataGridViewX1.Rows.Add(row);
                    }
                    //dataGridViewX1.DataSource =;
                }
                if (_cir.IsApproved)
                {
                    btnSave.Enabled = false;
                    dataGridViewX1.Columns[5].ReadOnly = true;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string msg = _cir.CreateBy != FISCA.Authentication.DSAServices.UserAccount ? "注意:您並非此項目的開設者" : "";
            if (MessageBox.Show("你是否要進行此操作?\n" + msg, "確認", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<string> log = new List<string>();
                int i = 1 ;
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    ((CreationItemsParticipateRecord)row.Tag).CanParticipate = row.Cells[5].Value == "True" ? true : false;
                    log.Add("" + i + "：年級:" + row.Cells[0].Value + ",班級:" + row.Cells[1].Value + ",座號:" + row.Cells[2].Value + ",姓名:" + row.Cells[3].Value + ",學號:" + row.Cells[4].Value + ",核可:" + (row.Cells[5].Value== "True" ? "是" : "否"));
                        i++;
                }
                lcipr.SaveAll();
                ApplicationLog.Log("服務學習線上開設", "核可作業", "已核可" + dataGridViewX1.Rows.Count + "筆資料\n" + string.Join("\n", log));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 可ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                row.Cells[5].Value = true;
            }
        }
        private void 不可ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                row.Cells[5].Value = false;
            }
        }

        
    }
}
