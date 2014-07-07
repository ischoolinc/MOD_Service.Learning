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
    public partial class ChangeTextForm : BaseForm
    {
        public string ChangeText = "";

        public ChangeTextForm()
        {
            InitializeComponent();
        }

        public ChangeTextForm(string FromNameString, string textName)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            textBoxX1.Text = textName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeText = textBoxX1.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
