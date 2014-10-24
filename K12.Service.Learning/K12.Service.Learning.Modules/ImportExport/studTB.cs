using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace K12.Service.Learning.Modules
{
    class studTB
    {
        public studTB(DataRow row)
        {
            ref_student_id = "" + row["id"];
            Student_Number = "" + row["student_number"];
            seat_no = "" + row["seat_no"];
            name = "" + row["name"];
            class_name = "" + row["class_name"];
        }

        public string ref_student_id { get; set; }
        public string name { get; set; }
        public string Student_Number { get; set; }

        public string seat_no { get; set; }

        public string class_name { get; set; }
    }
}
