using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;

namespace K12.SL.OrganizersStatistics
{
    public partial class OrganizersStatisticsForm : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();
        SetupObj setup = new SetupObj();
        FISCA.UDT.AccessHelper _A = new FISCA.UDT.AccessHelper();
        List<SLRecord> SLRList { get; set; }

        public OrganizersStatisticsForm()
        {
            InitializeComponent();
        }

        private void OrganizersStatisticsForm_Load(object sender, EventArgs e)
        {
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);

            //預設資料
            intSchoolYear.Value = int.Parse(K12.Data.School.DefaultSchoolYear);
            intSemester.Value = int.Parse(K12.Data.School.DefaultSemester);
            dateTimeInput1.Value = DateTime.Today.AddDays(-7);
            dateTimeInput2.Value = DateTime.Today;

            //預設畫面
            bgSelectSchoolYear.Enabled = true;
            gbDateTime.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!BGW.IsBusy)
            {
                btnStart.Enabled = false;
                setup.dtStart = dateTimeInput1.Value;
                setup.dtEnd = dateTimeInput2.Value;
                setup.IsOrganizer = cbOrganizer.Checked;
                setup.IsSchoolYear = cbSchoolYear.Checked;
                setup.SchoolYear = intSchoolYear.Value;
                setup.Semester = intSemester.Value;

                BGW.RunWorkerAsync();
            }
            else
            {
                MsgBox.Show("系統忙碌中\n稍後再試!!");
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            //條件依據學年度學期取資料
            if (setup.IsSchoolYear)
            {
                SLRList = _A.Select<SLRecord>(string.Format("school_year={0} and semester={1}", setup.SchoolYear.ToString(), setup.Semester.ToString()));

            }
            else //依據日期取資料
            {
                SLRList = _A.Select<SLRecord>(string.Format("occur_date>={0} and occur_date<{1}", setup.dtStart.ToShortDateString(), setup.dtEnd.ToShortDateString()));
            }
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = true;

            if (e.Error == null)
            {
                dataGridViewX1.Rows.Clear();

                if (SLRList.Count > 0)
                {
                    Dictionary<string, ValueObj> dic = GetTotol();
                    foreach (string each in dic.Keys)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridViewX1);
                        row.Cells[0].Value = each;
                        row.Cells[1].Value = dic[each].StudentList.Count;
                        row.Cells[2].Value = dic[each].人次;
                        row.Cells[3].Value = dic[each].總時數;
                        row.Tag = dic[each];
                        dataGridViewX1.Rows.Add(row);
                    }
                }
                else
                {
                    MsgBox.Show("查無資料!!");
                }
            }
            else
            {
                MsgBox.Show("系統發生錯誤:\n" + e.Error.Message);
            }
        }

        private Dictionary<string, ValueObj> GetTotol()
        {
            Dictionary<string, ValueObj> dic = new Dictionary<string, ValueObj>();
            SLRList.Sort(SortSLRList);
            //篩選的內容是主辦單位
            if (setup.IsOrganizer)
            {
                //統計主辦單位
                foreach (SLRecord each in SLRList)
                {
                    if (!dic.ContainsKey(each.Organizers))
                        dic.Add(each.Organizers, new ValueObj());

                    dic[each.Organizers].總時數 += each.Hours;
                    dic[each.Organizers].人次 += 1;
                    if (!dic[each.Organizers].StudentList.Contains(each.RefStudentID))
                    {
                        dic[each.Organizers].StudentList.Add(each.RefStudentID);
                    }

                }
            }
            else //篩選的內容是事由
            {
                //統計事由
                foreach (SLRecord each in SLRList)
                {
                    if (!dic.ContainsKey(each.Reason))
                        dic.Add(each.Reason, new ValueObj());

                    dic[each.Reason].總時數 += each.Hours;
                    dic[each.Reason].人次 += 1;
                    if (!dic[each.Reason].StudentList.Contains(each.RefStudentID))
                    {
                        dic[each.Reason].StudentList.Add(each.RefStudentID);
                    }
                }
            }

            return dic;
        }

        private int SortSLRList(SLRecord s1, SLRecord s2)
        {
            if (setup.IsOrganizer)
            {
                return s1.Organizers.CompareTo(s2.Organizers);
            }
            else
            {
                return s1.Reason.CompareTo(s2.Reason);
            }
        }


        private void checkBoxX4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSchoolYear.Checked)
            {
                bgSelectSchoolYear.Enabled = true;
                gbDateTime.Enabled = false;
            }
            else
            {
                bgSelectSchoolYear.Enabled = false;
                gbDateTime.Enabled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOrganizer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOrganizer.Checked)
            {
                Column1.HeaderText = "主辦單位";
            }
            else
            {
                Column1.HeaderText = "事由";
            }
        }

        private void 清空待處理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            K12.Presentation.NLDPanels.Student.RemoveFromTemp(K12.Presentation.NLDPanels.Student.TempSource);
        }

        private void 加入學生待處理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> AllList = new List<string>();
            foreach (DataGridViewRow row in dataGridViewX1.SelectedRows)
            {
                ValueObj obj = (ValueObj)row.Tag;
                AllList.AddRange(obj.StudentList);
            }
            K12.Presentation.NLDPanels.Student.AddToTemp(AllList);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            #region 匯出
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "匯出主辦單位與事由統計";
            saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;

            DataGridViewExport export = new DataGridViewExport(dataGridViewX1);
            export.Save(saveFileDialog1.FileName);

            if (new CompleteForm().ShowDialog() == DialogResult.Yes)
                System.Diagnostics.Process.Start(saveFileDialog1.FileName);
            #endregion
        }
    }
}
