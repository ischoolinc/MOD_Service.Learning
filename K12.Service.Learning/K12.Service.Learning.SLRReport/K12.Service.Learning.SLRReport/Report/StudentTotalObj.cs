using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace K12.Service.Learning.SLRReport
{
    class StudentTotalObj
    {


        /// <summary>
        /// 學生ID
        /// </summary>
        public string ref_student_id { get; set; }

        /// <summary>
        /// 班級ID
        /// </summary>
        public string ref_class_id { get; set; }

        /// <summary>
        /// 座號
        /// </summary>
        public string seat_no { get; set; }

        /// <summary>
        /// 學號
        /// </summary>
        public string student_number { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 學生姓名
        /// </summary>
        public string student_name { get; set; }

        /// <summary>
        /// 學生性別
        /// </summary>
        public string student_gender { get; set; }

        public decimal 需補時數
        {
            get
            {
                if (學期1統計 < 6)

                    return 6 - 學期1統計;
                else
                    return 0;
            }
        }

        public decimal 學期1統計 { get; set; }
        //decimal 學期2統計 { get; set; }
        //decimal 學期3統計 { get; set; }
        //decimal 學期4統計 { get; set; }
        //decimal 學期5統計 { get; set; }
        //decimal 學期6統計 { get; set; }

        public StudentTotalObj(DataRow row)
        {
            ref_student_id = "" + row[0];
            ref_class_id = "" + row[1];
            seat_no = "" + row[2];
            student_number = "" + row[3];
            student_name = "" + row[4];
            status = "" + row[5];
            string 性別 = "" + row[6];
            if (性別 == "1")
                student_gender = "男";
            else if (性別 == "0")
                student_gender = "女";
            else
                student_gender = "";

            學期1統計 = 0;
        }
    }
}
