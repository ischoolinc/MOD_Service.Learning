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
    public partial class ChangeIntForm : BaseForm
    {
        public decimal ChangeInt { get; set; }

        public ChangeIntForm()
        {
            InitializeComponent();
        }

        public ChangeIntForm(string FromNameString,decimal intName)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            inpHours.Text = intName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ChangeInt = decimal.Parse(inpHours.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;

        }
    }
}
