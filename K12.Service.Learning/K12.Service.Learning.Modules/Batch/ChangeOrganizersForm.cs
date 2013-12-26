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
    public partial class ChangeOrganizersForm : BaseForm
    {
        public string ChangeText = "";

        List<string> OrganizersList { get; set; }

        public ChangeOrganizersForm()
        {
            InitializeComponent();
        }

        public ChangeOrganizersForm(string FromNameString, string textName)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            comboBoxEx1.Text = textName;

            OrganizersList = tool.GetOrganizersTable();
            comboBoxEx1.Items.Add("");
            foreach (string organizers in OrganizersList)
            {
                if (!string.IsNullOrEmpty(organizers))
                {
                    comboBoxEx1.Items.Add(organizers);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeText = comboBoxEx1.Text.Trim();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

    }
}
