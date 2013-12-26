using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using FISCA.LogAgent;
using FISCA.Presentation.Controls;
using K12.Data;

namespace K12.Service.Learning.Modules
{
    [FISCA.Permission.FeatureCode("K12.Service.Learning.Modules.LearningItem.cs", "服務學習時數")]
    public partial class LearningItem : DetailContentBase
    {
        internal static FISCA.Permission.FeatureAce UserPermission;
        private BackgroundWorker BGW = new BackgroundWorker();
        private bool BkWBool = false;

        private StudentRecord student { get; set; }

        FISCA.UDT.AccessHelper _accessHelper = new FISCA.UDT.AccessHelper();

        List<SLRecord> SLRList { get; set; }

        public LearningItem()
        {
            InitializeComponent();

            Group = "服務學習記錄";

            BGW.DoWork += new DoWorkEventHandler(BkW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BkW_RunWorkerCompleted);

            UserPermission = FISCA.Permission.UserAcl.Current[FISCA.Permission.FeatureCodeAttribute.GetCode(GetType())];

            btnAdd.Visible = UserPermission.Editable;
            btnUpdate.Visible = UserPermission.Editable;
            btnDelete.Visible = UserPermission.Editable;
            btnView.Visible = UserPermission.Viewable & !UserPermission.Editable;

            LearningEvents.LearningChanged += new EventHandler(LearningEvents_LearningChanged);
        }

        /// <summary>
        /// 更新事件
        /// </summary>
        void LearningEvents_LearningChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, K12.Data.DataChangedEventArgs>(LearningEvents_LearningChanged), sender, e);
            }
            else
            {
                if (this.PrimaryKey != "")
                {
                    this.Loading = true;

                    if (BGW.IsBusy)
                    {
                        BkWBool = true;
                    }
                    else
                    {
                        BGW.RunWorkerAsync();
                    }
                }
            }
        }

        protected override void OnPrimaryKeyChanged(EventArgs e)
        {
            this.Loading = true;

            if (BGW.IsBusy)
            {
                BkWBool = true;
            }
            else
            {
                BGW.RunWorkerAsync();
            }
        }

        void BkW_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(this.PrimaryKey)) return;

            //取得學生
            student = Student.SelectByID(this.PrimaryKey);

            //取得服務學習檔案
            SLRList = _accessHelper.Select<SLRecord>(string.Format("ref_student_id='{0}'", this.PrimaryKey));
        }

        void BkW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (BkWBool)
            {
                BkWBool = false;
                BGW.RunWorkerAsync();
                return;
            }
            BindData();

            this.Loading = false;
        }

        private void BindData()
        {
            listView.Items.Clear();
            SLRList.Sort(SchoolYearComparer); //依發生日期排序
            foreach (SLRecord SLR in SLRList)
            {
                ListViewItem itm = new ListViewItem(SLR.SchoolYear.ToString());
                itm.SubItems.Add(SLR.Semester.ToString());
                itm.SubItems.Add(SLR.OccurDate.ToShortDateString());
                itm.SubItems.Add(SLR.Reason);
                itm.SubItems.Add(SLR.Hours.ToString());
                itm.SubItems.Add(SLR.Organizers);
                itm.SubItems.Add(SLR.RegisterDate.ToShortDateString());
                itm.SubItems.Add(SLR.Remark);
                itm.Tag = SLR;
                listView.Items.Add(itm);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LearningForm editor = new LearningForm(this.student);
            editor.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("請先選擇一筆您要修改的資料");
                return;
            }
            else if (listView.SelectedItems.Count > 1)
            {
                MsgBox.Show("選擇資料筆數過多，一次只能修改一筆資料");
                return;
            }

            LearningForm editor = new LearningForm(listView.SelectedItems[0].Tag as SLRecord, UserPermission);
            editor.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MsgBox.Show("必須選擇一筆以上資料!!");
                return;
            }

            List<SLRecord> SLRList = new List<SLRecord>();

            if (MsgBox.Show("確認刪除所選擇[服務學習記錄]?", "確認", MessageBoxButtons.YesNo) == DialogResult.No) return;

            foreach (ListViewItem item in listView.SelectedItems)
            {
                SLRecord editor = item.Tag as SLRecord;
                SLRList.Add(editor);
            }

            try
            {
                this._accessHelper.DeletedValues(SLRList);
            }
            catch (Exception ex)
            {
                MsgBox.Show("刪除[服務學習記錄]資料失敗" + ex.Message);
                return;
            }

            StringBuilder sb = new StringBuilder();
            StudentRecord sr = K12.Data.Student.SelectByID(this.PrimaryKey);
            sb.Append("班級「" + (string.IsNullOrEmpty(sr.RefClassID) ? "" : sr.Class.Name) + "」");
            sb.Append("座號「" + (sr.SeatNo.HasValue ? sr.SeatNo.Value.ToString() : "") + "」");
            sb.AppendLine("學生「" + sr.Name + "」");
            foreach (SLRecord att in SLRList)
            {
                sb.AppendLine("日期「" + att.OccurDate.ToShortDateString() + "」");
            }
            sb.AppendLine("「服務學習記錄」已被刪除。");

            ApplicationLog.Log("服務學習記錄", "刪除服務學習記錄", "student", this.PrimaryKey, sb.ToString());
            LearningEvents.RaiseAssnChanged();
            MsgBox.Show("刪除服務學習記錄成功");
        }

        //依日期排序
        private int SchoolYearComparer(SLRecord x, SLRecord y)
        {
            return y.OccurDate.CompareTo(x.OccurDate);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                LearningForm editor = new LearningForm(listView.SelectedItems[0].Tag as SLRecord, UserPermission);
                editor.ShowDialog();
            }
        }
    }
}