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
    public partial class ChangeSchoolYearSemester : BaseForm
    {
        public int ChangeSchoolYear { get; set; }
        public int ChangeSemester { get; set; }

        public ChangeSchoolYearSemester()
        {
            InitializeComponent();
        }

        public ChangeSchoolYearSemester(string FromNameString,int school,int semester)
        {
            InitializeComponent();

            this.Text = string.Format("批次修改{0}資料", FromNameString);
            integerInput1.Value = school;
            integerInput2.Value = semester;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ChangeSchoolYear = integerInput1.Value;
            ChangeSemester = integerInput2.Value;
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
