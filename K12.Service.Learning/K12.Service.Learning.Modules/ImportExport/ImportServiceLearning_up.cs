using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.Import;
using System.Xml;
using K12.Data;
using FISCA.DSAUtil;
using K12.Data;
using Campus.DocumentValidator;
using FISCA.Presentation.Controls;
using FISCA.LogAgent;
using FISCA.UDT;
using System.Data;

namespace K12.Service.Learning.Modules
{
    class ImportServiceLearning_up : ImportWizard
    {

        /// <summary>
        /// 取得學生學號:學生系統編號比對資料
        /// </summary>
        FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

        Dictionary<string, SLRecord> Log_SLRDic { get; set; }

        //設定檔
        private ImportOption mOption;


        AccessHelper _accessHelper = new AccessHelper();

        Dictionary<string, studTB> StudentDic_ByNum { get; set; }

        Dictionary<string, studTB> StudentDic_ByID { get; set; }

        //學生Record,與學號對應
        private Dictionary<string, SLRecord> ByStudentNumber = new Dictionary<string, SLRecord>();

        /// <summary>
        /// 準備動作
        /// </summary>
        public override void Prepare(ImportOption Option)
        {
            mOption = Option;

            GetStudent();
        }

        /// <summary>
        /// 每1000筆資料,分批執行匯入
        /// Return是Log資訊
        /// </summary>
        public override string Import(List<Campus.DocumentValidator.IRowStream> Rows)
        {
            List<SLRecord> updateList = GetUPList(Rows);

            if (updateList.Count > 0)
            {
                try
                {
                    _accessHelper.UpdateValues(updateList.ToArray());
                }
                catch (Exception ex)
                {
                    MsgBox.Show("於更新資料時發生錯誤!!\n" + ex.Message);
                }
            }

            if (updateList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("匯入更新服務學習時數");
                sb.AppendLine("");
                foreach (SLRecord each in updateList)
                {
                    if (StudentDic_ByID.ContainsKey(each.RefStudentID))
                    {
                        studTB tb = StudentDic_ByID[each.RefStudentID];
                        if (Log_SLRDic.ContainsKey(each.UID))
                        {
                            SLRecord log_each = Log_SLRDic[each.UID];

                            sb.AppendLine(string.Format("班級「{0}」座號「{1}」學號「{2}」學生「{3}」", tb.class_name, tb.seat_no, tb.Student_Number, tb.name));
                            
                            if (!string.IsNullOrEmpty(SetLog(log_each.SchoolYear.ToString(), each.SchoolYear.ToString(), "學年度")))
                            {
                                sb.AppendLine(SetLog(log_each.SchoolYear.ToString(), each.SchoolYear.ToString(), "學年度"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.Semester.ToString(), each.Semester.ToString(), "學期")))
                            {
                                sb.AppendLine(SetLog(log_each.Semester.ToString(), each.Semester.ToString(), "學期"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.OccurDate.ToShortDateString(), each.OccurDate.ToShortDateString(), "日期")))
                            {
                                sb.AppendLine(SetLog(log_each.OccurDate.ToShortDateString(), each.OccurDate.ToShortDateString(), "日期"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.Hours.ToString(), each.Hours.ToString(), "時數")))
                            {
                                sb.AppendLine(SetLog(log_each.Hours.ToString(), each.Hours.ToString(), "時數"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.Reason, each.Reason, "事由")))
                            {
                                sb.AppendLine(SetLog(log_each.Reason, each.Reason, "事由"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.InternalOrExternal, each.InternalOrExternal, "校內校外")))
                            {
                                sb.AppendLine(SetLog(log_each.InternalOrExternal, each.InternalOrExternal, "校內校外"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.Organizers, each.Organizers, "主辦單位")))
                            {
                                sb.AppendLine(SetLog(log_each.Organizers, each.Organizers, "主辦單位"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.RegisterDate.ToShortDateString(), each.RegisterDate.ToShortDateString(), "登錄日期")))
                            {
                                sb.AppendLine(SetLog(log_each.RegisterDate.ToShortDateString(), each.RegisterDate.ToShortDateString(), "登錄日期"));
                            }

                            if (!string.IsNullOrEmpty(SetLog(log_each.Remark, each.Remark, "備註")))
                            {
                                sb.AppendLine(SetLog(log_each.Remark, each.Remark, "備註"));
                            }

                            sb.AppendLine("");
                        }
                    }
                }

                ApplicationLog.Log("匯入服務學習", "更新", sb.ToString());
            }

            return "";
        }

        private string SetLog(string x, string y, string z)
        {
            if (x != y)
            {
                return string.Format("{0}由「{1}」修改為「{2}」", z, x, y);
            }
            else
            {
                return "";
            }
        }

        private Dictionary<string, SLRecord> GetSLList(List<IRowStream> Rows)
        {
            Dictionary<string, SLRecord> dic = new Dictionary<string, SLRecord>();
            Log_SLRDic = new Dictionary<string, SLRecord>();
            List<string> slIDList = new List<string>();
            foreach (IRowStream each in Rows)
            {
                string UID = each.GetValue("服務學習時數系統編號");
                slIDList.Add(UID);
            }

            foreach (SLRecord each in _accessHelper.Select<SLRecord>(slIDList))
            {
                if (!dic.ContainsKey(each.UID))
                {
                    dic.Add(each.UID, each);

                    Log_SLRDic.Add(each.UID, each.CopyExtension());

                }
            }
            return dic;
        }

        /// <summary>
        /// 取得學生學號 vs 系統編號
        /// </summary>
        /// <param name="Rows"></param>
        /// <returns></returns>
        private void GetStudent()
        {
            StudentDic_ByID = new Dictionary<string, studTB>();
            StudentDic_ByNum = new Dictionary<string, studTB>();
            //取得比對序

            DataTable dt = _queryHelper.Select("select student.id,student.student_number,student.seat_no,student.name,class.class_name from student left join class on class.id=student.ref_class_id");
            foreach (DataRow row in dt.Rows)
            {
                studTB s = new studTB(row);

                if (string.IsNullOrEmpty(s.Student_Number))
                    continue;

                if (!StudentDic_ByNum.ContainsKey(s.Student_Number))
                {
                    StudentDic_ByNum.Add(s.Student_Number, s);
                }

                if (!StudentDic_ByID.ContainsKey(s.ref_student_id))
                {
                    StudentDic_ByID.Add(s.ref_student_id, s);
                }
            }
        }

        //取得所有服務學習時數資料
        private List<SLRecord> GetUPList(List<IRowStream> Rows)
        {
            Dictionary<string, SLRecord> IttList = GetSLList(Rows);

            List<SLRecord> slrlist = new List<SLRecord>();

            foreach (IRowStream each in Rows)
            {

                string UID = each.GetValue("服務學習時數系統編號");

                if (IttList.ContainsKey(UID))
                {
                    SLRecord slr = IttList[UID];

                    slr.SchoolYear = int.Parse(each.GetValue("學年度"));
                    slr.Semester = int.Parse(each.GetValue("學期"));
                    slr.OccurDate = DateTime.Parse((each.GetValue("發生日期")));
                    slr.Reason = "" + each.GetValue("事由");
                    slr.Hours = decimal.Parse(each.GetValue("時數"));
                    slr.Organizers = "" + each.GetValue("主辦單位");

                    string register = each.GetValue("登錄日期");
                    if (!string.IsNullOrEmpty(register))
                    {
                        slr.RegisterDate = DateTime.Parse(each.GetValue("登錄日期"));
                    }
                    else
                    {
                        slr.RegisterDate = DateTime.Today;
                    }

                    slr.Remark = "" + each.GetValue("備註");
                    slr.InternalOrExternal = "" + each.GetValue("校內校外"); //new

                    slrlist.Add(slr);
                }

            }
            return slrlist;
        }

        /// <summary>
        /// 取得驗證規則(動態建置XML內容)
        /// </summary>
        public override string GetValidateRule()
        {
            //動態建立XmlRule
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Properties.Resources.ImportServiceLearning_up);
            return xmlDoc.InnerXml;
        }

        /// <summary>
        /// 設定匯入功能,所提供的匯入動作
        /// </summary>
        public override ImportAction GetSupportActions()
        {
            //新增或更新
            return ImportAction.Update;
        }
    }
}
