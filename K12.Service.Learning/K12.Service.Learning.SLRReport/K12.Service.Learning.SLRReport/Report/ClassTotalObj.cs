using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12.Service.Learning.SLRReport
{
    class ClassTotalObj
    {
        /// <summary>
        /// 班級ID
        /// </summary>
        public string ref_class_id { get; set; }

        /// <summary>
        /// 班級名稱
        /// </summary>
        public string class_name { get; set; }

        /// <summary>
        /// 班級序號
        /// </summary>
        public string class_index { get; set; }

        /// <summary>
        /// 年級
        /// </summary>
        public string class_grade_year { get; set; }

        /// <summary>
        /// 老師ID
        /// </summary>
        public string ref_tearch_id { get; set; }

        /// <summary>
        /// 老師姓名
        /// </summary>
        public string tearch_name { get; set; }

        /// <summary>
        /// 老師暱稱
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 學生清單
        /// </summary>
        public List<StudentTotalObj> StudentObjList { get; set; }

        /// <summary>
        /// 學生ID清單
        /// </summary>
        public List<string> StudentIDList { get; set; }

        public Dictionary<string, StudentTotalObj> StudentDic { get; set; }

        public ClassTotalObj(DataRow row)
        {
            ref_class_id = "" + row[0];
            class_name = "" + row[1];
            ref_tearch_id = "" + row[2];
            tearch_name = "" + row[3];
            nickname = "" + row[4];
            class_grade_year = "" + row[5];
            class_index = "" + row[6];

            StudentObjList = new List<StudentTotalObj>();
            StudentIDList = new List<string>();
            StudentDic = new Dictionary<string, StudentTotalObj>();
        }

        public void SetSLRInStudent(SLRecord slr)
        {
            if (StudentDic.ContainsKey(slr.RefStudentID))
            {
                StudentDic[slr.RefStudentID].學期1統計 += slr.Hours;
            }
        }

        /// <summary>
        /// 取得老師名稱
        /// (包含暱稱)
        /// </summary>
        public string GetTeacherName()
        {
            if (!string.IsNullOrEmpty(tearch_name))
            {
                if (!string.IsNullOrEmpty(nickname))
                {
                    return tearch_name + "(" + nickname + ")";
                }
                else
                {
                    return tearch_name;
                }
            }
            else
                return "";
        }
    }
}
