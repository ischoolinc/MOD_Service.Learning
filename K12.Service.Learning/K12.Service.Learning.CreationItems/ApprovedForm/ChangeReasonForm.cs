using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.UDT;
using K12.Service.Learning.Modules;
namespace K12.Service.Learning.CreationItems
{
    public partial class ChangeReasonForm : BaseForm
    {
        AccessHelper _AccessHelper = new AccessHelper();

        public string ChangeText = "";

        BackgroundWorker BGW = new BackgroundWorker();

        List<K12.Service.Learning.Modules.DigitalCodeRecord> DCRecord { get; set; }

        string name = "";

        Dictionary<string, string> ReasonDic = new Dictionary<string, string>();

        public ChangeReasonForm()
        {
            InitializeComponent();
        }

        public ChangeReasonForm(string FromNameString, string textName)
        {
            InitializeComponent();
            name = FromNameString;
            textBoxX1.Text = textName;

            this.Text = string.Format("批次修改{0}資料(取得資料中)", name);

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);

            BGW.RunWorkerAsync();
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //取得事由代碼表
            DCRecord = _AccessHelper.Select<DigitalCodeRecord>();
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = string.Format("批次修改{0}資料", name);

            KeyValuePair<string, string> fkvp = new KeyValuePair<string, string>("", "");
            comboBoxEx1.Items.Add(fkvp);

            foreach (DigitalCodeRecord dcr in DCRecord)
            {
                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(dcr.Code + "-" + dcr.Content, dcr.Content);
                comboBoxEx1.Items.Add(kvp);

                if (!ReasonDic.ContainsKey(dcr.Code))
                {
                    ReasonDic.Add(dcr.Code, dcr.Content);
                }
            }

            comboBoxEx1.DisplayMember = "Key";
            comboBoxEx1.ValueMember = "Value";
            comboBoxEx1.SelectedIndex = 0;

            this.comboBoxEx1.TextChanged += new System.EventHandler(this.comboBoxEx1_TextChanged);
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            this.comboBoxEx1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBoxEx1_KeyUp);
        }

        private void comboBoxEx1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBoxX1.Focus();
                textBoxX1.Select(textBoxX1.Text.Length + 1, 0);
            }
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeyValuePair<string, string> kvp = (KeyValuePair<string, string>)comboBoxEx1.SelectedItem;
            textBoxX1.Text = kvp.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.comboBoxEx1.SelectedIndexChanged -= new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            this.comboBoxEx1.KeyUp -= new System.Windows.Forms.KeyEventHandler(this.comboBoxEx1_KeyUp);
            this.comboBoxEx1.TextChanged -= new System.EventHandler(this.comboBoxEx1_TextChanged);

            ChangeText = textBoxX1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            string comText = comboBoxEx1.Text;
            comText = comText.Remove(0, comText.IndexOf('-') + 1);

            string reasonValue = GetReason(comText);

            textBoxX1.Text = reasonValue;

        }

        private string GetReason(string comText)
        {
            string reasonValue = "";
            List<string> list = new List<string>();
            string[] reasonList = comText.Split(',');
            foreach (string each in reasonList)
            {
                string each1 = each.Replace("\r\n", "");
                if (ReasonDic.ContainsKey(each1))
                {
                    list.Add(ReasonDic[each1]);
                }
                else
                {
                    list.Add(each1);
                }
            }

            reasonValue = string.Join(",", list);
            return reasonValue;
        }
    }
}
