using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using K12.Data;
using FISCA.DSAUtil;
using K12.Data;
using Campus.DocumentValidator;
using FISCA.Presentation.Controls;
using FISCA.LogAgent;
using FISCA.UDT;
using System.Data;
using Campus.Import2014;

namespace K12.Service.Learning.Modules
{
    class ImportServiceLearning : ImportWizard
    {

        /// <summary>
        /// 取得學生學號:學生系統編號比對資料
        /// </summary>
        FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

        private ImportOption mOption;

        AccessHelper _accessHelper = new AccessHelper();

        Dictionary<string, studTB> StudentDic_ByNum { get; set; }

        Dictionary<string, studTB> StudentDic_ByID { get; set; }

        /// <summary>
        /// 準備動作
        /// </summary>
        public override void Prepare(ImportOption Option)
        {
            mOption = Option;
            //取得學生學號對比系統編號
            GetStudent();
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
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("匯入新增服務學習時數");
                foreach (SLRecord each in InsertList)
                {
                    if (StudentDic_ByID.ContainsKey(each.RefStudentID))
                    {
                        studTB tb = StudentDic_ByID[each.RefStudentID];

                        sb.AppendLine(string.Format("班級「{0}」座號「{1}」學號「{2}」學生「{3}」", tb.class_name, tb.seat_no, tb.Student_Number, tb.name));
                        sb.AppendLine(string.Format("學年度「{0}」學期「{1}」日期「{2}」時數「{3}」", each.SchoolYear.ToString(), each.Semester.ToString(), each.OccurDate.ToShortDateString(), each.Hours));
                        sb.AppendLine(string.Format("事由「{0}」主辦單位「{1}」校內校外「{2}」備註「{3}」", each.Reason, each.Organizers, each.InternalOrExternal, each.Remark));
                        sb.AppendLine("");
                    }
                }

                ApplicationLog.Log("匯入服務學習)", "新增", sb.ToString());
            }

            return "";
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

                if (StudentDic_ByNum.ContainsKey(Student_Number))
                {
                    SLRecord slr = new SLRecord();

                    slr.RefStudentID = StudentDic_ByNum[Student_Number].ref_student_id;
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

                    list.Add(slr);
                }

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
