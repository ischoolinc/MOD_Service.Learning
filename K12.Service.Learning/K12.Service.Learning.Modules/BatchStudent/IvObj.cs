using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;
using System.Data;

namespace K12.Service.Learning.Modules
{
    public class IvObj
    {
        public string ref_student_id { get; set; }
        public decimal? Hours { get; set; }
        public StudentRecord student { get; set; }
        public ClassRecord classObj { get; set; }

        //基本資料
        public string ClassName
        {
            get
            {
                if (classObj != null)
                {
                    return classObj.Name;
                }
                else
                {
                    return "";
                }
      
            }
        }
        public string SeatNo
        {
            get
            {
                if (student != null)
                {
                    if (student.SeatNo.HasValue)
                    {
                        return student.SeatNo.Value.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
        }
        public string Name
        {
            get
            {
                if (student != null)
                {
                    return student.Name;
                }
                else
                {
                    return "";
                }
            }
        }
        public string StudentNumber
        {
            get
            {
                if (student != null)
                {
                    return student.StudentNumber;
                }
                else
                {
                    return "";
                }
            }
        }

        public string School_Year { get; set; }
        public string Semester { get; set; }

        public IvObj(DataRow row)
        {
            ref_student_id = "" + row["ref_student_id"];
            decimal test = 0;
            decimal.TryParse("" + row["SUM_hours"], out test);
            Hours = test;

            School_Year = "";
            Semester = "";
        }

        public IvObj(string id)
        {
            ref_student_id = id;
            //Hours = 0;
            School_Year = "";
            Semester = "";
        }
    }
}
