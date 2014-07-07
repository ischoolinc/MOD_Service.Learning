using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using K12.Service.Learning.Modules;

namespace K12.Service.Learning.CreationItems
{
    public partial class ChangeAllDataForm : BaseForm
    {
        public int 學年度;
        public int 學期;
        public string 日期;
        public string 事由;
        public decimal 時數;
        public string 主辦單位;
        public string 備註;

        public ChangeAllDataForm()
        {
            InitializeComponent();
        }

        public ChangeAllDataForm(string FromNameString, SLRecord obj)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            intSchoolYear.Value = obj.SchoolYear;
            intSemester.Value = obj.Semester;
            dtOccurDate.Value = obj.OccurDate;
            txtReason.Text = obj.Reason;
            textBoxX1.Text = obj.Hours.ToString();
            txtOrganizers.Text = obj.Organizers;
            txtRemark.Text = obj.Remark;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            學年度 = intSchoolYear.Value;
            學期 = intSemester.Value;
            日期 = dtOccurDate.Value.ToShortDateString();
            事由 = txtReason.Text;

            if (時數轉換器.IsDecimal(textBoxX1.Text))
            {
                if (時數轉換器.SentDecimalByString(textBoxX1.Text))
                {
                    時數 = decimal.Parse(textBoxX1.Text);
                }
                else
                {
                    MsgBox.Show("時數並非整數\n本畫面僅能輸入小數後1位!!");
                }
            }

            主辦單位 = txtOrganizers.Text;
            備註 = txtRemark.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;

        }
    }
}
