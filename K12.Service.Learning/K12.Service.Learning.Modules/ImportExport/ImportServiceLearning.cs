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
    class ImportServiceLearning : ImportWizard
    {

        /// <summary>
        /// 取得Record or Insert
        /// </summary>
        AccessHelper _accesshelper = new AccessHelper();

        /// <summary>
        /// 取得學生學號:學生系統編號比對資料
        /// </summary>
        FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

        //設定檔
        private ImportOption mOption;

        //Log內容
        private StringBuilder mstrLog = new StringBuilder();

        AccessHelper _accessHelper = new AccessHelper();

        Dictionary<string, string> StudentNumberByID { get; set; }

        //學生Record,與學號對應
        private Dictionary<string, SLRecord> ByStudentNumber = new Dictionary<string, SLRecord>();

        /// <summary>
        /// 準備動作
        /// </summary>
        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
            //取得學生學號對比系統編號
            StudentNumberByID = GetStudent();
        }

        /// <summary>
        /// 每1000筆資料,分批執行匯入
        /// Return是Log資訊
        /// </summary>
        public override string Import(List<Campus.DocumentValidator.IRowStream> Rows)
        {
            List<SLRecord> InsertList = new List<SLRecord>();

            InsertList = GetInsertList(Rows);

            if (InsertList.Count > 0)
            {
                try
                {
                    _accessHelper.InsertValues(InsertList.ToArray());
                }
                catch (Exception ex)
                {
                    MsgBox.Show("於新增資料時發生錯誤!!\n" + ex.Message);
                }
            }

            if (InsertList.Count > 0)
            {
                ApplicationLog.Log("匯入服務學習記錄(新增)", "匯入", "已匯入新增服務學習時數\n共" + InsertList.Count + "筆");
            }

            return "";
        }

        /// <summary>
        /// 取得學生學號 vs 系統編號
        /// </summary>
        /// <param name="Rows"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetStudent()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //取得比對序

            DataTable dt = _queryHelper.Select("select id,student_number from student");
            foreach (DataRow row in dt.Rows)
            {
                string StudentID = "" + row[0];
                string Student_Number = "" + row[1];

                if (string.IsNullOrEmpty(Student_Number))
                    continue;

                if (!dic.ContainsKey(Student_Number))
                {
                    dic.Add(Student_Number, StudentID);
                }
            }

            return dic;
        }

        //取得所有服務學習時數資料
        private List<SLRecord> GetInsertList(List<IRowStream> Rows)
        {
            List<SLRecord> list = new List<SLRecord>();

            foreach (IRowStream each in Rows)
            {

                string Student_Number = each.GetValue("學號");

                ////如果學號為空,該資料將會被跳過
                //if (string.IsNullOrEmpty(Student_Number))
                //    continue;
                ////如果學號不存在系統內,將會被跳過
                //if (!StudentNumberByID.ContainsKey(Student_Number))
                //    continue;

                SLRecord slr = new SLRecord();
                slr.RefStudentID = StudentNumberByID[Student_Number];
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

                list.Add(slr);

            }
            return list;
        }

        /// <summary>
        /// 取得驗證規則(動態建置XML內容)
        /// </summary>
        public override string GetValidateRule()
        {
            //動態建立XmlRule
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Properties.Resources.ImportServiceLearning);
            return xmlDoc.InnerXml;
        }

        /// <summary>
        /// 設定匯入功能,所提供的匯入動作
        /// </summary>
        public override ImportAction GetSupportActions()
        {
            //新增或更新
            return ImportAction.Insert;
        }
    }
}
