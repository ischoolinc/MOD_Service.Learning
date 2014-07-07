using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using Aspose.Words;
using System.IO;
using FISCA.DSAUtil;
using FISCA.UDT;
using K12.Data;
using System.Xml;
using System.Diagnostics;
using K12.Service.Learning.Modules;

namespace K12.Service.Learning.CreationItems
{
    public partial class RecordCard : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();
        int 服務學習記錄筆數 = 20;
        private string ConfigName = "K12.Service.Learning.CreationItems.RecordCard.config.1";
        public RecordCard()
        {
            InitializeComponent();
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
        }
        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ConfigName);
            Aspose.Words.Document Template;

            if (ConfigurationInCadre.Template == null)
            {
                Campus.Report.ReportConfiguration ConfigurationInCadre_1 = new Campus.Report.ReportConfiguration(ConfigName);
                ConfigurationInCadre_1.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數記錄卡欄位總表, Campus.Report.TemplateType.Word);
                Template = ConfigurationInCadre_1.Template.ToDocument();
            }
            else
            {
                Template = ConfigurationInCadre.Template.ToDocument();
            }
            DataTable table = new DataTable();
            for (int x = 1; x <= 服務學習記錄筆數; x++)
            {
                //table.Columns.Add(string.Format("報名開始時間_{0}", x));
                //table.Columns.Add(string.Format("報名結束時間_{0}", x));
                table.Columns.Add(string.Format("學年度_{0}", x));
                table.Columns.Add(string.Format("學期_{0}", x));
                table.Columns.Add(string.Format("主辦單位_{0}", x));
                table.Columns.Add(string.Format("服務日期_{0}", x));
                table.Columns.Add(string.Format("備註_{0}", x));
                //table.Columns.Add(string.Format("服務地點_{0}", x));
                table.Columns.Add(string.Format("時數_{0}", x));
                table.Columns.Add(string.Format("服務事由_{0}", x));
                //table.Columns.Add(string.Format("人數上限_{0}", x));
                table.Columns.Add(string.Format("登錄日期_{0}", x));
            }

            table.Columns.Add("一上總時數");
            table.Columns.Add("一下總時數");
            table.Columns.Add("二上總時數");
            table.Columns.Add("二下總時數");
            table.Columns.Add("三上總時數");
            table.Columns.Add("三下總時數");

            table.Columns.Add("學校名稱");
            table.Columns.Add("班級");
            table.Columns.Add("座號");
            //table.Columns.Add("學年度");
            //table.Columns.Add("學期");
            table.Columns.Add("姓名");
            table.Columns.Add("學號");
            table.Columns.Add("性別");
            table.Columns.Add("服務學習記錄筆數");
            table.Columns.Add("列印日期");

            List<string> studentSelectedSource = K12.Presentation.NLDPanels.Student.SelectedSource;
            Dictionary<string, K12.Data.StudentRecord> dsr = K12.Data.Student.SelectByIDs(studentSelectedSource).ToDictionary(x => x.ID, x => x);
            //tool._Q = new FISCA.Data.QueryHelper();
            //List<SLRecord> lslr = tool._Q.Select<SLRecord>("ref_student_id IN ('" + string.Join("','", studentSelectedSource) + "')");
            DataTable dt = tool._Q.Select("select * from $k12.service.learning.record where ref_student_id IN ('" + string.Join("','", studentSelectedSource) + "')");
            Dictionary<string, List<SLRecord>> dslr = new Dictionary<string, List<SLRecord>>();
            foreach (DataRow row in dt.Rows)
            {
                if (!dslr.ContainsKey("" + row["ref_student_id"]))
                    dslr.Add("" + row["ref_student_id"], new List<SLRecord>());
                dslr["" + row["ref_student_id"]].Add(new SLRecord()
                {
                    RefStudentID = "" + row["ref_student_id"],
                    Hours = decimal.Parse("" + row["hours"]),
                    OccurDate = DateTime.Parse("" + row["occur_date"]),
                    Organizers = "" + row["organizers"],
                    Reason = "" + row["reason"],
                    RegisterDate = DateTime.Parse("" + row["register_date"]),
                    Remark = "" + row["remark"],
                    SchoolYear = int.Parse("" + row["school_year"]),
                    Semester = int.Parse("" + row["semester"]),
                });
            }
            Dictionary<string,SemesterHistoryRecord> lshr = K12.Data.SemesterHistory.SelectByStudentIDs(K12.Presentation.NLDPanels.Student.SelectedSource).ToDictionary(x => x.RefStudentID, x => x);
            foreach (string RefStudentID in studentSelectedSource)
            {
                DataRow row = table.NewRow();
                row["學校名稱"] = School.ChineseName;
                row["列印日期"] = DateTime.Now.ToString("yyyy/M/d");
                if (dsr.ContainsKey(RefStudentID))
                {
                    row["班級"] = dsr[RefStudentID].Class != null ? dsr[RefStudentID].Class.Name : "";
                    row["座號"] = dsr[RefStudentID].SeatNo.HasValue ? dsr[RefStudentID].SeatNo.Value.ToString() : "";
                    row["姓名"] = dsr[RefStudentID].Name;
                    row["學號"] = dsr[RefStudentID].StudentNumber;
                    row["性別"] = dsr[RefStudentID].Gender;
                }
                if (dslr.ContainsKey(RefStudentID))
                {
                    int y = 1;
                    Dictionary<string, decimal> dhours = new Dictionary<string, decimal>();
                    foreach (SLRecord slr in dslr[RefStudentID])
                    {
                        row[string.Format("學年度_{0}", y)] = slr.SchoolYear;
                        row[string.Format("學期_{0}", y)] = slr.Semester;
                        row[string.Format("主辦單位_{0}", y)] = slr.Organizers;
                        row[string.Format("服務日期_{0}", y)] = slr.OccurDate.ToString("yyyy/M/d");
                        row[string.Format("備註_{0}", y)] = slr.Remark;

                        row[string.Format("時數_{0}", y)] = slr.Hours;
                        row[string.Format("服務事由_{0}", y)] = slr.Reason;
                        row[string.Format("登錄日期_{0}", y)] = slr.RegisterDate.ToString("yyyy/M/d");
                        string key = slr.SchoolYear + "#" + slr.Semester;
                        if (!dhours.ContainsKey(key))
                        {
                            dhours.Add(key, 0);
                        }
                        dhours[key] += slr.Hours;
                        y++;
                    }
                    row["服務學習記錄筆數"] = y - 1;
                    if (lshr.ContainsKey(RefStudentID))
                    {
                        foreach (SemesterHistoryItem item2 in lshr[RefStudentID].SemesterHistoryItems)
                        {
                            string gy = "",sem = "";
                            switch (item2.GradeYear)
                            {
                                case 1:
                                case 7:
                                    gy = "一";
                                    break;
                                case 2:
                                case 8:
                                    gy = "二";
                                    break;
                                case 3:
                                case 9:
                                    gy = "三";
                                    break;
                            }
                            switch (item2.Semester)
                            {
                                case 1:
                                    sem = "上";
                                    break;
                                case 2:
                                    sem = "下";
                                    break;
                            }
                            if (table.Columns.Contains(gy + sem + "總時數") && dhours.ContainsKey(item2.SchoolYear + "#" + item2.Semester))
                                row[gy + sem + "總時數"] = dhours[item2.SchoolYear + "#" + item2.Semester];
                        }
                    }
                }
                table.Rows.Add(row);
            }
            Document PageOne = (Document)Template.Clone(true);
            PageOne.MailMerge.Execute(table);
            e.Result = PageOne;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BGW.IsBusy)
                MsgBox.Show("忙碌中,稍後再試!!");
            else
                BGW.RunWorkerAsync();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //取得設定檔
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ConfigName);
            Campus.Report.TemplateSettingForm TemplateForm;
            //畫面內容(範本內容,預設樣式
            if (ConfigurationInCadre.Template != null)
            {
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數記錄卡欄位總表, Campus.Report.TemplateType.Word));
            }
            else
            {
                ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數記錄卡欄位總表, Campus.Report.TemplateType.Word);
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數記錄卡欄位總表, Campus.Report.TemplateType.Word));
            }

            //預設名稱
            TemplateForm.DefaultFileName = "服務學習時數記錄卡";

            //如果回傳為OK
            if (TemplateForm.ShowDialog() == DialogResult.OK)
            {
                //設定後樣試,回傳
                ConfigurationInCadre.Template = TemplateForm.Template;
                //儲存
                ConfigurationInCadre.Save();
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "另存新檔";
            sfd.FileName = "班級點名表_合併欄位總表.doc";
            sfd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                    fs.Write(Properties.Resources.服務學習時數記錄卡欄位總表, 0, Properties.Resources.服務學習時數記錄卡欄位總表.Length);
                    fs.Close();
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch
                {
                    FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "另存檔案失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = true;

            if (e.Cancelled)
            {
                MsgBox.Show("作業已被中止!!");
            }
            else
            {
                if (e.Error == null)
                {
                    Document inResult = (Document)e.Result;

                    try
                    {
                        SaveFileDialog SaveFileDialog1 = new SaveFileDialog();

                        SaveFileDialog1.Filter = "Word (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                        SaveFileDialog1.FileName = "班級點名單(週報表樣式)";

                        if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            inResult.Save(SaveFileDialog1.FileName);
                            Process.Start(SaveFileDialog1.FileName);
                        }
                        else
                        {
                            FISCA.Presentation.Controls.MsgBox.Show("檔案未儲存");
                            return;
                        }
                    }
                    catch
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("檔案儲存錯誤,請檢查檔案是否開啟中!!");
                        return;
                    }

                    this.Close();
                }
                else
                {
                    MsgBox.Show("列印資料發生錯誤\n" + e.Error.Message);
                }
            }
        }
    }
}
