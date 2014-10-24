using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.LogAgent;

namespace K12.Service.Learning.Modules
{
    public partial class DetailFrom : BaseForm
    {
        public decimal? NowDecimal { get; set; }
        BackgroundWorker BGW = new BackgroundWorker();
        IvObj _StudentItem { get; set; }
        Congig _config { get; set; }
        public DetailFrom(IvObj obj, Congig config)
        {
            InitializeComponent();
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            _StudentItem = obj;
            _config = config;
            if(_StudentItem.Hours.HasValue)
            {
            NowDecimal = _StudentItem.Hours.Value;
            }

            StringBuilder sb = new StringBuilder();
            if (_StudentItem.classObj != null)
            {
                sb.Append("班級：" + _StudentItem.classObj.Name);
            }

            sb.Append("　座號：" + _StudentItem.SeatNo);
            sb.Append("　姓名：" + _StudentItem.Name);
            sb.Append("　學號：" + _StudentItem.StudentNumber);
            labelX1.Text = sb.ToString();
            BGW.RunWorkerAsync();
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //背景模式取得單一學生的服務學習資料
            List<SLRecord> list;
            if (_config.是否使用學年期)
            {
                list = tool._A.Select<SLRecord>(string.Format("ref_student_id='{0}' and school_year='{1}' and semester='{2}'", _StudentItem.ref_student_id, "" + _config.學年度, "" + _config.學期));
            }
            else
            {
                list = tool._A.Select<SLRecord>(string.Format("ref_student_id='{0}'", _StudentItem.ref_student_id));
            }
            e.Result = list;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<SLRecord> list = (List<SLRecord>)e.Result;
            list.Sort(Sort);
            foreach (SLRecord each in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewX1);
                row.Cells[0].Value = "" + each.SchoolYear;
                row.Cells[1].Value = "" + each.Semester;
                row.Cells[2].Value = each.OccurDate.ToShortDateString();
                row.Cells[3].Value = each.Reason;
                row.Cells[4].Value = "" + each.Hours;
                row.Cells[5].Value = each.Organizers;
                row.Cells[6].Value = each.InternalOrExternal;
                row.Cells[7].Value = each.Remark;
                row.Cells[8].Value = each.RegisterDate.ToShortDateString();
                row.Tag = each;
                dataGridViewX1.Rows.Add(row);
            }
        }

        private int Sort(SLRecord a, SLRecord b)
        {
            return a.OccurDate.CompareTo(b.OccurDate);

        }

        private void 刪除所選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MsgBox.Show("您確定要刪除所選明細資料嗎?", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteData();
            }
            else
            {
                MsgBox.Show("刪除動作已取消。");
            }
        }

        private void DeleteData()
        {
            StringBuilder sb = new StringBuilder();
            if (_StudentItem.classObj != null)
            {
                sb.Append("班級「" + _StudentItem.classObj.Name + "」");
            }
            sb.Append("座號「" + _StudentItem.SeatNo + "」");
            sb.AppendLine("姓名「" + _StudentItem.Name + "」");
            sb.AppendLine("服務學習記錄已進行刪除動作：");

            List<SLRecord> DeleteList = new List<SLRecord>();
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                SLRecord slr = (SLRecord)row.Tag;
                sb.Append("日期「" + slr.OccurDate.ToShortDateString() + "」");
                sb.Append("時數「" + slr.Hours + "」");
                sb.AppendLine("事由「" + slr.Reason + "」");
                DeleteList.Add(slr);
            }

            tool._A.DeletedValues(DeleteList);

            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                dataGridViewX1.Rows.Remove(row);
            }

            ApplicationLog.Log("服務時數查詢", "刪除", "student", _StudentItem.ref_student_id, sb.ToString());

            if (dataGridViewX1.Rows.Count != 0)
            {
                decimal count = 0;
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    decimal a = 0;
                    decimal.TryParse("" + row.Cells[4].Value, out a);
                    count += a;
                }
                NowDecimal = count;
            }
            else
            {
                NowDecimal = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
