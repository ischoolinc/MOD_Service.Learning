using FISCA.Presentation.Controls;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K12.Service.Learning.CreationItems
{
    public partial class Item : BaseForm
    {
        public CreationItemsRecord _cir;
        public Item(CreationItemsRecord cir,ComboBox.ObjectCollection cboc)
        {
            InitializeComponent();
            this.Text = "項目";
            inpSchoolYear.Value = int.Parse(School.DefaultSchoolYear);
            inpSemester.Value = int.Parse(School.DefaultSemester);
            foreach (string item in cboc)
            {
                inpOrganizers.Items.Add(item);
            }
            if (cir.UID != null)
            {
                _cir = cir;
                inpRegistStartTime.Value = _cir.RegistStartTime;
                inpRegistEndTime.Value = _cir.RegistEndTime;
                inpSchoolYear.Value = _cir.SchoolYear;
                inpSemester.Value = _cir.Semester;
                inpOrganizers.Text = _cir.Organizers  ;
                inpOccurDate.Value = _cir.OccurDate;

                inpLocation.Text = _cir.Location ;
                inpEpectedHours.Value = double.Parse(""+_cir.ExpectedHours) ;

                 inpParticipateLimit.Value = _cir.ParticipateLimit;
                inpReason.Text = _cir.Reason ;
                inpRemark.Text= _cir.Remark;
            }
            if (_cir.IsApproved)
            {
                inpRegistStartTime.Enabled = false;
                inpRegistEndTime.Enabled = false;
                inpSchoolYear.Enabled = false;
                inpSemester.Enabled = false;
                inpOrganizers.Enabled = false;
                inpOccurDate.Enabled = false;

                inpLocation.Enabled = false;
                inpEpectedHours.Enabled = false;

                inpParticipateLimit.Enabled = false;
                inpReason.Enabled = false;
                inpRemark.Enabled = false;
                btnSave.Enabled = false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool errorTag = false;
            if (inpRegistStartTime.Value >= inpRegistEndTime.Value)
            {
                errorProvider1.SetError(inpRegistStartTime, "報名開始時間不可於報名結束時間後");
                errorTag = true;
            }
            if (inpRegistEndTime.Value >= inpOccurDate.Value)
            {
                errorProvider1.SetError(inpRegistEndTime, "報名結束時間不可於發生日期後");
                errorTag = true;
            }
            if (errorTag)
                return;
            _cir.RegistStartTime = inpRegistStartTime.Value;
            _cir.RegistEndTime = inpRegistEndTime.Value;
            _cir.SchoolYear = inpSchoolYear.Value;
            _cir.Semester = inpSemester.Value;
            _cir.Organizers = inpOrganizers.Text;
            _cir.OccurDate = inpOccurDate.Value;

            _cir.Location = inpLocation.Text;
            _cir.ExpectedHours = decimal.Parse(""+inpEpectedHours.Value);

            _cir.ParticipateLimit = inpParticipateLimit.Value;
            _cir.Reason = inpReason.Text;
            _cir.Remark = inpRemark.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
