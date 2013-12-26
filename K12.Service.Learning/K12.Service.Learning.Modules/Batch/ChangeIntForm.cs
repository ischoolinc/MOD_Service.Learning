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
            textBoxX1.Text = intName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (時數轉換器.IsDecimal(textBoxX1.Text))
            {
                if (時數轉換器.SentDecimalByString(textBoxX1.Text))
                {
                    ChangeInt = decimal.Parse(textBoxX1.Text);
                    this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                }
                else
                {
                    MsgBox.Show("輸入內容必須大於0或是整數,\n小數點僅可輸入後兩位!!");
                }
            }
            else
            {
                MsgBox.Show("輸入內容並非數字!!");
            }
        }
    }
}
