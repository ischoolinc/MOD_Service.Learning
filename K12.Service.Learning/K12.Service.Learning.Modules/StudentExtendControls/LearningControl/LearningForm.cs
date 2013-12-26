using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using FISCA.LogAgent;
using FISCA.Presentation.Controls;
using K12.Data;
using FISCA.Data;

namespace K12.Service.Learning.Modules
{
    /// <summary>
    /// 新增或修改獎勵資料的畫面。
    /// 修改時，因為只能修改一個學生的某一筆獎勵資料，所以只要傳入一個 MeritRecordEditor 物件即可
    /// 新增時，可以同時對多位學生增加相同的獎勵紀錄，所以要傳入多位學生的資料，但不傳入MeritRecordEditor 物件，此物件會在儲存時由每位學生記錄取得。
    /// </summary>
    public partial class LearningForm : BaseForm
    {
        StudentRecord _student;
        SLRecord _SLRecord;

        Dictionary<string, string> ResonDic = new Dictionary<string, string>();
        FISCA.UDT.AccessHelper _accessHelper = new FISCA.UDT.AccessHelper();

        BackgroundWorker BGW = new BackgroundWorker();

        List<DigitalCodeRecord> DCRecord { get; set; }

        /// <summary>
        /// Constructor，新增時使用。
        /// </summary>
        /// <param name="students"></param>
        public LearningForm(StudentRecord student)
        {
            InitializeComponent();

            #region 新增

            this._student = student;

            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;

            intSchoolYear.Text = School.DefaultSchoolYear;
            intSemester.Text = School.DefaultSemester;

            Text = "服務學習時數 【 新增 】";

            #endregion
        }

        /// <summary>
        /// Constructor，修改時使用
        /// </summary>
        /// <param name="_demeritRecordEditor"></param>
        public LearningForm(SLRecord SLR, FISCA.Permission.FeatureAce permission)
        {
            InitializeComponent();

            #region 修改
            this._SLRecord = SLR;
            _student = Student.SelectByID(SLR.RefStudentID);

            if (LearningItem.UserPermission.Editable)
                Text = string.Format("服務學習時數 【 修改：{0}，{1} 】", _student.Name, SLR.OccurDate.ToShortDateString());
            else
                Text = string.Format("服務學習時數 【 檢視：{0}，{1} 】", _student.Name, SLR.OccurDate.ToShortDateString());

            SetPerm(permission);
            #endregion
        }

        /// <summary>
        /// 修改 或 檢視
        /// </summary>
        private void SetPerm(FISCA.Permission.FeatureAce permission)
        {
            btnSave.Visible = permission.Editable;
            intSchoolYear.Enabled = permission.Editable;
            intSemester.Enabled = permission.Editable;
            dateTimeInput1.Enabled = permission.Editable;
            dateTimeInput2.Enabled = permission.Editable;
            textBoxX3.Enabled = permission.Editable;
            foreach (Control each in Controls)
            {
                if (each is DevComponents.DotNetBar.Controls.TextBoxX)
                    (each as DevComponents.DotNetBar.Controls.TextBoxX).ReadOnly = !permission.Editable;
            }
        }

        private void LearningForm_Load(object sender, EventArgs e)
        {
            #region Load

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            
            SetForm = false;
            
            BGW.RunWorkerAsync();

            #endregion
        }

        bool SetForm
        {
            set
            {
                if (value)
                {
                    this.Text = "服務學習記錄";
                }
                else
                {
                    this.Text = "服務學習記錄(處理中)";
                }

                intSchoolYear.Enabled = value;
                intSemester.Enabled = value;
                textBoxX2.Enabled = value;
                dateTimeInput1.Enabled = value;
                dateTimeInput2.Enabled = value;
                cbOrganizers.Enabled = value;
                textBoxX3.Enabled = value;
                comboBoxEx1.Enabled = value;
                txtReason.Enabled = value;
                btnSave.Enabled = value;
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得事由代碼表
            DCRecord = _accessHelper.Select<DigitalCodeRecord>();

            //取得系統內的
            List<string> list = tool.GetOrganizersTable();
            e.Result = list;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetForm = true;

            List<string> list = (List<string>)e.Result;
            cbOrganizers.Items.Add("");
            foreach (string organizers in list)
            {
                if (!string.IsNullOrEmpty(organizers))
                {
                    cbOrganizers.Items.Add(organizers);
                }
            }

            SetReasonList();

            //如果是修改模式，則把資料填到畫面上。
            if (this._SLRecord != null)
            {
                intSchoolYear.Value = _SLRecord.SchoolYear; //學年
                intSemester.Value = _SLRecord.Semester; //學期

                dateTimeInput1.Value = _SLRecord.OccurDate; //發生日期
                txtReason.Text = _SLRecord.Reason; //事由
                textBoxX3.Text = _SLRecord.Hours.ToString(); //時數
                cbOrganizers.Text = _SLRecord.Organizers; //主辦單位

                textBoxX2.Text = _SLRecord.Remark; //備註

                dateTimeInput2.Value = _SLRecord.RegisterDate; //登錄日期

            }

            txtReason.Focus();
        }

        private void SetReasonList()
        {
            KeyValuePair<string, string> fkvp = new KeyValuePair<string, string>("", "");
            comboBoxEx1.Items.Add(fkvp);

            foreach (DigitalCodeRecord each in DCRecord)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(each.Code + "-" + each.Content, each.Content);
                comboBoxEx1.Items.Add(kvp);

                if (!ResonDic.ContainsKey(each.Code))
                {
                    ResonDic.Add(each.Code, "" + each.Content);
                }
            }

            comboBoxEx1.DisplayMember = "Key";
            comboBoxEx1.ValueMember = "Value";
            comboBoxEx1.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Save

            if (string.IsNullOrEmpty(textBoxX3.Text))
            {
                MsgBox.Show("請輸入[時數]。");
                return;
            }

            if (!時數轉換器.SentDecimalByString(textBoxX3.Text))
            {
                MsgBox.Show("[時數]必須為整數\n或僅限輸入小數後兩位!!");
                return;
            }

            if (cbOrganizers.SelectedIndex < 1 && string.IsNullOrEmpty(cbOrganizers.Text))
            {
                DialogResult dr = MsgBox.Show("主辦單位未輸入內容，是否繼續儲存？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

            }


            if (txtReason.Text.Trim() == "")
            {
                DialogResult dr = MsgBox.Show("事由未輸入，是否繼續儲存？", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (this._SLRecord == null)
            {
                #region 新增

                List<SLRecord> insertList = new List<SLRecord>();
                try
                {
                    insertList = Insert();
                    _accessHelper.InsertValues(insertList);
                    LearningEvents.RaiseAssnChanged();
                }
                catch (Exception ex)
                {
                    MsgBox.Show("新增[服務學習記錄]發生錯誤: \n" + ex.Message);
                    return;
                }

                MsgBox.Show("新增[服務學習記錄]成功!");
                #endregion

                #region 單筆新增Log
                StringBuilder sb = new StringBuilder();
                sb.Append("班級「" + (string.IsNullOrEmpty(_student.RefClassID) ? "" : _student.Class.Name) + "」");
                sb.Append("座號「" + (_student.SeatNo.HasValue ? _student.SeatNo.Value.ToString() : "") + "」");
                sb.AppendLine("學生「" + _student.Name + "」");
                sb.AppendLine("新增一筆服務學習記錄。");
                sb.AppendLine("學 年 度「" + insertList[0].SchoolYear.ToString() + "」");
                sb.AppendLine("學　　期「" + insertList[0].Semester.ToString() + "」");
                sb.AppendLine("發生日期「" + insertList[0].OccurDate.ToShortDateString() + "」");
                sb.AppendLine("時　　數「" + insertList[0].Hours.ToString() + "」");
                sb.AppendLine("事　　由「" + insertList[0].Reason + "」");
                sb.AppendLine("主辦單位「" + insertList[0].Organizers + "」");
                sb.AppendLine("備　　註「" + insertList[0].Remark + "」");
                sb.AppendLine("登錄日期「" + insertList[0].RegisterDate.ToShortDateString() + "」");

                ApplicationLog.Log("服務學習記錄模組", "新增服務學習記錄", "student", _student.ID, sb.ToString());
                #endregion
            }
            else
            {
                #region 修改

                List<SLRecord> updateList = new List<SLRecord>();

                //Log用
                SLRecord _LogSLRecord = new SLRecord();
                _LogSLRecord.SchoolYear = _SLRecord.SchoolYear;
                _LogSLRecord.Semester = _SLRecord.Semester;
                _LogSLRecord.Hours = _SLRecord.Hours;
                _LogSLRecord.Reason = _SLRecord.Reason;
                _LogSLRecord.Remark = _SLRecord.Remark;
                _LogSLRecord.Organizers = _SLRecord.Organizers;
                _LogSLRecord.OccurDate = _SLRecord.OccurDate;
                _LogSLRecord.RegisterDate = _SLRecord.RegisterDate;


                try
                {
                    Modify();

                    updateList.Add(this._SLRecord);
                    _accessHelper.UpdateValues(updateList);
                    LearningEvents.RaiseAssnChanged();

                }
                catch (Exception ex)
                {
                    MsgBox.Show("修改[服務學習記錄]發生錯誤: \n" + ex.Message);
                    return;
                }

                MsgBox.Show("修改[服務學習記錄]成功!");
                #endregion

                #region 修改Log

                StringBuilder sb = new StringBuilder();
                sb.Append("班級「" + (string.IsNullOrEmpty(_student.RefClassID) ? "" : _student.Class.Name) + "」");
                sb.Append("座號「" + (_student.SeatNo.HasValue ? _student.SeatNo.Value.ToString() : "") + "」");
                sb.AppendLine("學生「" + _student.Name + "」");
                sb.AppendLine("修改一筆服務學習記錄。");
                sb.AppendLine("學 年 度 「" + _LogSLRecord.SchoolYear.ToString() + "」修改為「" + updateList[0].SchoolYear.ToString() + "」");
                sb.AppendLine("學　　期「" + _LogSLRecord.Semester.ToString() + "」修改為「" + updateList[0].Semester.ToString() + "」");
                sb.AppendLine("發生日期「" + _LogSLRecord.OccurDate.ToShortDateString() + "」修改為「" + updateList[0].OccurDate.ToShortDateString() + "」");
                sb.AppendLine("時　　數「" + _LogSLRecord.Hours.ToString() + "」修改為「" + updateList[0].Hours.ToString() + "」");
                sb.AppendLine("事　　由「" + _LogSLRecord.Reason + "」修改為「" + updateList[0].Reason + "」");
                sb.AppendLine("主辦單位「" + _LogSLRecord.Organizers + "」修改為「" + updateList[0].Organizers + "」");
                sb.AppendLine("備　　註「" + _LogSLRecord.Remark + "」修改為「" + updateList[0].Remark + "」");
                sb.AppendLine("登錄日期「" + _LogSLRecord.RegisterDate.ToShortDateString() + "」修改為「" + updateList[0].RegisterDate.ToShortDateString() + "」");

                ApplicationLog.Log("服務學習記錄模組", "修改服務學習記錄", "student", _student.ID, sb.ToString());

                #endregion
            }

            this.Close();
            #endregion
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modify()
        {
            //把畫面的資料填回 物件中
            this.FillDataToEditor(this._SLRecord);
        }

        private List<SLRecord> Insert()
        {
            List<SLRecord> newEditors = new List<SLRecord>();

            //對所有學生，都準備好相關的 物件
            SLRecord dre = new SLRecord();
            dre.RefStudentID = this._student.ID;

            //把畫面的資料填回 物件中
            this.FillDataToEditor(dre);
            newEditors.Add(dre);
            return newEditors;
        }

        //把畫面資料填到 Editor 中。因為新增和修改模式都會有這些程式碼
        //所以抽出來成為一個函數，以避免程式碼重複。
        private void FillDataToEditor(SLRecord editor)
        {
            //把畫面的資料填回 MeritRecordEditor 物件中

            editor.SchoolYear = intSchoolYear.Value;
            editor.Semester = intSemester.Value;

            editor.Hours = decimal.Parse(textBoxX3.Text); //時數
            editor.Reason = txtReason.Text.Trim(); //事由
            editor.Organizers = cbOrganizers.Text.Trim(); //單位
            editor.Remark = textBoxX2.Text.Trim(); //備註
            editor.OccurDate = dateTimeInput1.Value; //發生日期
            editor.RegisterDate = dateTimeInput2.Value; //登錄日期

        }

        private void cboReasonRef_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReason.Focus();
                txtReason.Select(txtReason.Text.Length + 1, 0);
            }
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            if (時數轉換器.IsDecimal(textBoxX3.Text))
            {
                if (時數轉換器.SentDecimalByString(textBoxX3.Text))
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(textBoxX3, "[時數]僅限小數後兩位!!");
                }
            }
            else
            {
                errorProvider1.SetError(textBoxX3, "[時數]並非數字!!");
            }
        }

        private void textBoxX1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxX3.Focus();
                textBoxX3.SelectAll();
            }
        }

        private void textBoxX3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBoxEx1.Focus();
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)comboBoxEx1.SelectedItem;
            txtReason.Text = kvp.Value;
        }

        private void comboBoxEx1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReason.Focus();
                txtReason.Select(txtReason.Text.Length + 1, 0);
            }
        }

        private void txtReason_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string reasonValue = "";
                List<string> list = new List<string>();
                string[] reasonList = txtReason.Text.Split(',');
                foreach (string each in reasonList)
                {
                    string each1 = each.Replace("\r\n", "");
                    if (ResonDic.ContainsKey(each1))
                    {
                        list.Add(ResonDic[each1]);
                    }
                    else
                    {
                        list.Add(each1);
                    }
                }

                reasonValue = string.Join(",", list);

                txtReason.Text = reasonValue;
            }
        }
    }
}