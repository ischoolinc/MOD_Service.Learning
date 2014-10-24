using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace K12.Service.Learning.Modules
{
    public partial class ChangeInorOutForm : BaseForm
    {
        public string ChangeText = "";

        List<string> OrganizersList { get; set; }

        public ChangeInorOutForm()
        {
            InitializeComponent();
        }

        public ChangeInorOutForm(string FromNameString, string textName)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            comboBoxEx1.Text = textName;

            comboBoxEx1.Items.Add("");
            comboBoxEx1.Items.Add("校內");
            comboBoxEx1.Items.Add("校外");

            if (textName == "校內")
                comboBoxEx1.SelectedIndex = 1;
            else if (textName == "校外")
                comboBoxEx1.SelectedIndex = 2;
            else
                comboBoxEx1.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeText = comboBoxEx1.Text.Trim();
            if (comboBoxEx1.SelectedIndex == 1)
                ChangeText = "校內";
            else if (comboBoxEx1.SelectedIndex == 2)
                ChangeText = "校外";
            else
                ChangeText = "";

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

    }
}
