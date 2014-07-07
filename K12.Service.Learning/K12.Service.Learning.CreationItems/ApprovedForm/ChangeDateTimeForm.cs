using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace K12.Service.Learning.CreationItems
{
    public partial class ChangeDateTimeForm : BaseForm
    {
        public DateTime ChangeTime { get; set; }

        public ChangeDateTimeForm()
        {
            InitializeComponent();
        }

        public ChangeDateTimeForm(string FromNameString, string dtName)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            dateTimeInput1.Value = DateTime.Parse(dtName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeTime = dateTimeInput1.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }


    }
}
