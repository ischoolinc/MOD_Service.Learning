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

namespace K12.Service.Learning.CreationItems
{
    public partial class RollSheet : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        int 學生多少個 = 150;
        private string ConfigName = "K12.Service.Learning.CreationItems.RollSheet.config.1";
        List<CreationItemsRecord> lcir;
        public RollSheet(IEnumerable<CreationItemsRecord> iecir)
        {
            InitializeComponent();
            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
            this.lcir = iecir.ToList();
        }
        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            Campus.Report.ReportConfiguration ConfigurationInCadre = new Campus.Report.ReportConfiguration(ConfigName);
            Aspose.Words.Document Template;

            if (ConfigurationInCadre.Template == null)
            {
                Campus.Report.ReportConfiguration ConfigurationInCadre_1 = new Campus.Report.ReportConfiguration(ConfigName);
                ConfigurationInCadre_1.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數點名單欄位總表, Campus.Report.TemplateType.Word);
                Template = ConfigurationInCadre_1.Template.ToDocument();
            }
            else
            {
                Template = ConfigurationInCadre.Template.ToDocument();
            }
            DataTable table = new DataTable();
            for (int x = 1; x <= 學生多少個; x++)
            {
                table.Columns.Add(string.Format("班級_{0}", x));
                table.Columns.Add(string.Format("座號_{0}", x));
                table.Columns.Add(string.Format("姓名_{0}", x));
                table.Columns.Add(string.Format("學號_{0}", x));
                table.Columns.Add(string.Format("性別_{0}", x));
            }

            table.Columns.Add("學校名稱");
            table.Columns.Add("報名開始時間");
            table.Columns.Add("報名結束時間");
            table.Columns.Add("學年度");
            table.Columns.Add("學期");
            table.Columns.Add("主辦單位");
            table.Columns.Add("服務日期");
            table.Columns.Add("備註");
            table.Columns.Add("服務地點");
            table.Columns.Add("預計時數");
            table.Columns.Add("服務事由");
            table.Columns.Add("人數上限");
            table.Columns.Add("人數");
            table.Columns.Add("列印日期");
            List<string> where = new List<string>();
            foreach (CreationItemsRecord item in lcir)
            {
                where.Add("ref_creationitemsrecord_id = '" + item.UID + "'");
            }
            DataTable dt = tool._Q.Select("select ref_student_id,ref_creationitemsrecord_id from $k12.service.learning.creationitemsparticipaterecord where can_participate = true and " + string.Join(" or ", where));
            where = null;
            List<string> lsid = new List<string>();
            Dictionary<string, List<string>> dsid = new Dictionary<string, List<string>>();
            foreach (DataRow row in dt.Rows)
            {
                if (!lsid.Contains("" + row[0]))
                    lsid.Add("" + row[0]);
                if (!dsid.ContainsKey("" + row[1]))
                    dsid.Add("" + row[1], new List<string>());
                if (!dsid["" + row[1]].Contains("" + row[0]))
                    dsid["" + row[1]].Add("" + row[0]);
            }
            Dictionary<string,K12.Data.StudentRecord> dsr = K12.Data.Student.SelectByIDs(lsid).ToDictionary(x=>x.ID,x=>x);
            foreach (CreationItemsRecord item in lcir)
            {
                DataRow row = table.NewRow();
                row["學校名稱"] = K12.Data.School.ChineseName;
                row["報名開始時間"] = item.RegistStartTime;
                row["報名結束時間"] = item.RegistEndTime;
                row["學年度"] = item.SchoolYear;
                row["學期"] = item.Semester;
                row["主辦單位"] = item.Organizers;
                row["服務日期"] = item.OccurDate.ToString("yyyy/M/d");
                row["備註"] = item.Remark;
                row["服務地點"] = item.Location;
                row["預計時數"] = item.ExpectedHours;
                row["服務事由"] = item.Reason;
                row["人數上限"] = item.ParticipateLimit;
                row["列印日期"] = DateTime.Today.ToShortDateString();
                
                int y = 1;
                if (dsid.ContainsKey(item.UID))
                {
                    foreach (string sid in dsid[item.UID])
                    {
                        StudentRecord tmp = dsr[sid];
                        if (y <= 學生多少個)
                        {
                            row[string.Format("班級_{0}", y)] = tmp.Class != null ? tmp.Class.Name : "";
                            row[string.Format("座號_{0}", y)] = tmp.SeatNo.HasValue ? tmp.SeatNo.Value.ToString() : "";
                            row[string.Format("姓名_{0}", y)] = tmp.Name;
                            row[string.Format("學號_{0}", y)] = tmp.StudentNumber;
                            row[string.Format("性別_{0}", y)] = tmp.Gender;
                            y++;
                        }
                    }
                }
                row["人數"] = y-1;
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
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數點名單欄位總表, Campus.Report.TemplateType.Word));
            }
            else
            {
                ConfigurationInCadre.Template = new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數點名單欄位總表, Campus.Report.TemplateType.Word);
                TemplateForm = new Campus.Report.TemplateSettingForm(ConfigurationInCadre.Template, new Campus.Report.ReportTemplate(Properties.Resources.服務學習時數點名單欄位總表, Campus.Report.TemplateType.Word));
            }

            //預設名稱
            TemplateForm.DefaultFileName = "服務學習時數點名單";

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
                    fs.Write(Properties.Resources.服務學習時數點名單欄位總表, 0, Properties.Resources.服務學習時數點名單欄位總表.Length);
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
