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
    /// �s�W�έק���y��ƪ��e���C
    /// �ק�ɡA�]���u��ק�@�Ӿǥͪ��Y�@�����y��ơA�ҥH�u�n�ǤJ�@�� MeritRecordEditor ����Y�i
    /// �s�W�ɡA�i�H�P�ɹ�h��ǥͼW�[�ۦP�����y�����A�ҥH�n�ǤJ�h��ǥͪ���ơA�����ǤJMeritRecordEditor ����A������|�b�x�s�ɥѨC��ǥͰO�����o�C
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
        /// Constructor�A�s�W�ɨϥΡC
        /// </summary>
        /// <param name="students"></param>
        public LearningForm(StudentRecord student)
        {
            InitializeComponent();

            #region �s�W

            this._student = student;

            dateTimeInput1.Value = DateTime.Today;
            dateTimeInput2.Value = DateTime.Today;

            intSchoolYear.Text = School.DefaultSchoolYear;
            intSemester.Text = School.DefaultSemester;

            Text = "�A�Ⱦǲ߮ɼ� �i �s�W �j";

            #endregion
        }

        /// <summary>
        /// Constructor�A�ק�ɨϥ�
        /// </summary>
        /// <param name="_demeritRecordEditor"></param>
        public LearningForm(SLRecord SLR, FISCA.Permission.FeatureAce permission)
        {
            InitializeComponent();

            #region �ק�
            this._SLRecord = SLR;
            _student = Student.SelectByID(SLR.RefStudentID);

            if (LearningItem.UserPermission.Editable)
                Text = string.Format("�A�Ⱦǲ߮ɼ� �i �ק�G{0}�A{1} �j", _student.Name, SLR.OccurDate.ToShortDateString());
            else
                Text = string.Format("�A�Ⱦǲ߮ɼ� �i �˵��G{0}�A{1} �j", _student.Name, SLR.OccurDate.ToShortDateString());

            SetPerm(permission);
            #endregion
        }

        /// <summary>
        /// �ק� �� �˵�
        /// </summary>
        private void SetPerm(FISCA.Permission.FeatureAce permission)
        {
            btnSave.Visible = permission.Editable;
            intSchoolYear.Enabled = permission.Editable;
            intSemester.Enabled = permission.Editable;
            dateTimeInput1.Enabled = permission.Editable;
            dateTimeInput2.Enabled = permission.Editable;
            textBoxX3.Enabled = permission.Editable;
            cbIAndE.Enabled = permission.Editable; //new 2014/9/9

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
                    this.Text = "�A�Ⱦǲ߰O��";
                }
                else
                {
                    this.Text = "�A�Ⱦǲ߰O��(�B�z��)";
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
            //���o�ƥѥN�X��
            DCRecord = _accessHelper.Select<DigitalCodeRecord>();

            //���o�t�Τ���
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

            //�p�G�O�ק�Ҧ��A�h���ƶ��e���W�C
            if (this._SLRecord != null)
            {
                intSchoolYear.Value = _SLRecord.SchoolYear; //�Ǧ~
                intSemester.Value = _SLRecord.Semester; //�Ǵ�

                dateTimeInput1.Value = _SLRecord.OccurDate; //�o�ͤ��
                txtReason.Text = _SLRecord.Reason; //�ƥ�
                textBoxX3.Text = _SLRecord.Hours.ToString(); //�ɼ�
                cbOrganizers.Text = _SLRecord.Organizers; //�D����

                if (_SLRecord.InternalOrExternal == "�դ�")
                    cbIAndE.SelectedIndex = 1; //�դ�
                else if (_SLRecord.InternalOrExternal == "�ե~")
                    cbIAndE.SelectedIndex = 2; //�ե~
                else
                    cbIAndE.SelectedIndex = 0; //������

                textBoxX2.Text = _SLRecord.Remark; //�Ƶ�

                dateTimeInput2.Value = _SLRecord.RegisterDate; //�n�����

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
            //2023/3/14 - �W�[���ҨϥΪ̬O�_����J�ɶ�
            if (dateTimeInput1.Text == "0001/01/01 00:00:00" || dateTimeInput1.Text == "")
            {
                errorProvider1.SetError(dateTimeInput1, "�п�J�ɶ����");
                return;
            }
            else
            {
                errorProvider1.SetError(dateTimeInput1, "");
            }

            #region Save

            if (string.IsNullOrEmpty(textBoxX3.Text))
            {
                MsgBox.Show("�п�J[�ɼ�]�C");
                return;
            }

            if (!�ɼ��ഫ��.SentDecimalByString(textBoxX3.Text))
            {
                MsgBox.Show("[�ɼ�]���������\n�ζȭ���J�p�ƫ���!!");
                return;
            }

            if (cbOrganizers.SelectedIndex < 1 && string.IsNullOrEmpty(cbOrganizers.Text))
            {
                DialogResult dr = MsgBox.Show("�D���쥼��J���e�A�O�_�~���x�s�H", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

            }


            if (txtReason.Text.Trim() == "")
            {
                DialogResult dr = MsgBox.Show("�ƥѥ���J�A�O�_�~���x�s�H", MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (this._SLRecord == null)
            {
                #region �s�W

                List<SLRecord> insertList = new List<SLRecord>();
                try
                {
                    insertList = Insert();
                    _accessHelper.InsertValues(insertList);
                    LearningEvents.RaiseAssnChanged();
                }
                catch (Exception ex)
                {
                    MsgBox.Show("�s�W[�A�Ⱦǲ߰O��]�o�Ϳ��~: \n" + ex.Message);
                    return;
                }

                MsgBox.Show("�s�W[�A�Ⱦǲ߰O��]���\!");
                #endregion

                #region �浧�s�WLog
                StringBuilder sb = new StringBuilder();
                sb.Append("�Z�šu" + (string.IsNullOrEmpty(_student.RefClassID) ? "" : _student.Class.Name) + "�v");
                sb.Append("�y���u" + (_student.SeatNo.HasValue ? _student.SeatNo.Value.ToString() : "") + "�v");
                sb.AppendLine("�ǥ͡u" + _student.Name + "�v");
                sb.AppendLine("�s�W�@���A�Ⱦǲ߰O���C");
                sb.AppendLine("�� �~ �סu" + insertList[0].SchoolYear.ToString() + "�v");
                sb.AppendLine("�ǡ@�@���u" + insertList[0].Semester.ToString() + "�v");
                sb.AppendLine("�o�ͤ���u" + insertList[0].OccurDate.ToShortDateString() + "�v");
                sb.AppendLine("�ɡ@�@�ơu" + insertList[0].Hours.ToString() + "�v");
                sb.AppendLine("�ơ@�@�ѡu" + insertList[0].Reason + "�v");
                sb.AppendLine("�D����u" + insertList[0].Organizers + "�v");
                sb.AppendLine("�դ��ե~�u" + insertList[0].InternalOrExternal + "�v");
                sb.AppendLine("�ơ@�@���u" + insertList[0].Remark + "�v");
                sb.AppendLine("�n������u" + insertList[0].RegisterDate.ToShortDateString() + "�v");

                ApplicationLog.Log("�A�Ⱦǲ߰O���Ҳ�", "�s�W�A�Ⱦǲ߰O��", "student", _student.ID, sb.ToString());
                #endregion
            }
            else
            {
                #region �ק�

                List<SLRecord> updateList = new List<SLRecord>();

                //Log��
                SLRecord _LogSLRecord = new SLRecord();
                _LogSLRecord.SchoolYear = _SLRecord.SchoolYear;
                _LogSLRecord.Semester = _SLRecord.Semester;
                _LogSLRecord.Hours = _SLRecord.Hours;
                _LogSLRecord.Reason = _SLRecord.Reason;
                _LogSLRecord.Remark = _SLRecord.Remark;
                _LogSLRecord.InternalOrExternal = _SLRecord.InternalOrExternal;
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
                    MsgBox.Show("�ק�[�A�Ⱦǲ߰O��]�o�Ϳ��~: \n" + ex.Message);
                    return;
                }

                MsgBox.Show("�ק�[�A�Ⱦǲ߰O��]���\!");
                #endregion

                #region �ק�Log

                StringBuilder sb = new StringBuilder();
                sb.Append("�Z�šu" + (string.IsNullOrEmpty(_student.RefClassID) ? "" : _student.Class.Name) + "�v");
                sb.Append("�y���u" + (_student.SeatNo.HasValue ? _student.SeatNo.Value.ToString() : "") + "�v");
                sb.AppendLine("�ǥ͡u" + _student.Name + "�v");
                sb.AppendLine("�ק�@���A�Ⱦǲ߰O���C");
                sb.AppendLine("�� �~ �� �u" + _LogSLRecord.SchoolYear.ToString() + "�v�קאּ�u" + updateList[0].SchoolYear.ToString() + "�v");
                sb.AppendLine("�ǡ@�@���u" + _LogSLRecord.Semester.ToString() + "�v�קאּ�u" + updateList[0].Semester.ToString() + "�v");
                sb.AppendLine("�o�ͤ���u" + _LogSLRecord.OccurDate.ToShortDateString() + "�v�קאּ�u" + updateList[0].OccurDate.ToShortDateString() + "�v");
                sb.AppendLine("�ɡ@�@�ơu" + _LogSLRecord.Hours.ToString() + "�v�קאּ�u" + updateList[0].Hours.ToString() + "�v");
                sb.AppendLine("�ơ@�@�ѡu" + _LogSLRecord.Reason + "�v�קאּ�u" + updateList[0].Reason + "�v");
                sb.AppendLine("�դ��ե~�u" + _LogSLRecord.InternalOrExternal + "�v�קאּ�u" + updateList[0].InternalOrExternal + "�v");
                sb.AppendLine("�D����u" + _LogSLRecord.Organizers + "�v�קאּ�u" + updateList[0].Organizers + "�v");
                sb.AppendLine("�ơ@�@���u" + _LogSLRecord.Remark + "�v�קאּ�u" + updateList[0].Remark + "�v");
                sb.AppendLine("�n������u" + _LogSLRecord.RegisterDate.ToShortDateString() + "�v�קאּ�u" + updateList[0].RegisterDate.ToShortDateString() + "�v");

                ApplicationLog.Log("�A�Ⱦǲ߰O���Ҳ�", "�ק�A�Ⱦǲ߰O��", "student", _student.ID, sb.ToString());

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
            //��e������ƶ�^ ����
            this.FillDataToEditor(this._SLRecord);
        }

        private List<SLRecord> Insert()
        {
            List<SLRecord> newEditors = new List<SLRecord>();

            //��Ҧ��ǥ͡A���ǳƦn������ ����
            SLRecord dre = new SLRecord();
            dre.RefStudentID = this._student.ID;

            //��e������ƶ�^ ����
            this.FillDataToEditor(dre);
            newEditors.Add(dre);
            return newEditors;
        }

        //��e����ƶ�� Editor ���C�]���s�W�M�ק�Ҧ����|���o�ǵ{���X
        //�ҥH��X�Ӧ����@�Ө�ơA�H�קK�{���X���ơC
        private void FillDataToEditor(SLRecord editor)
        {
            //��e������ƶ�^ MeritRecordEditor ����

            editor.SchoolYear = intSchoolYear.Value;
            editor.Semester = intSemester.Value;

            editor.Hours = decimal.Parse(textBoxX3.Text); //�ɼ�
            editor.Reason = txtReason.Text.Trim(); //�ƥ�
            editor.Organizers = cbOrganizers.Text.Trim(); //���
            editor.Remark = textBoxX2.Text.Trim(); //�Ƶ�
            editor.OccurDate = dateTimeInput1.Value; //�o�ͤ��
            editor.RegisterDate = dateTimeInput2.Value; //�n�����

            if (cbIAndE.SelectedIndex == 1)
                editor.InternalOrExternal = "�դ�"; //�n�����
            else if (cbIAndE.SelectedIndex == 2)
                editor.InternalOrExternal = "�ե~"; //�n�����
            else
                editor.InternalOrExternal = ""; //�n�����
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
            if (�ɼ��ഫ��.IsDecimal(textBoxX3.Text))
            {
                if (�ɼ��ഫ��.SentDecimalByString(textBoxX3.Text))
                {
                    errorProvider1.Clear();
                }
                else
                {
                    errorProvider1.SetError(textBoxX3, "[�ɼ�]�ȭ��p�ƫ���!!");
                }
            }
            else
            {
                errorProvider1.SetError(textBoxX3, "[�ɼ�]�ëD�Ʀr!!");
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