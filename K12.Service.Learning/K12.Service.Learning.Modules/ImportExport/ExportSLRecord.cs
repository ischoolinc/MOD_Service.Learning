using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.UDT;
using SmartSchool.API.PlugIn;
using K12.Data;

namespace K12.Service.Learning.Modules
{
    class ExportSLRecord : SmartSchool.API.PlugIn.Export.Exporter
    {
        private AccessHelper helper = new AccessHelper();

        Dictionary<string, StudentRecord> DicStudent = new Dictionary<string, StudentRecord>();

        //建構子
        public ExportSLRecord()
        {
            this.Image = null;
            this.Text = "匯出服務學習記錄";
        }

        public override void InitializeExport(SmartSchool.API.PlugIn.Export.ExportWizard wizard)
        {
            wizard.ExportableFields.AddRange("學年度", "學期", "發生日期", "事由", "時數", "主辦單位", "登錄日期", "備註");

            wizard.ExportPackage += (sender, e) =>
            {
                List<SLRecord> allrecords = new List<SLRecord>();

                allrecords = helper.Select<SLRecord>(string.Format("ref_student_id in ('{0}')", string.Join("','", e.List)));

                List<StudentRecord> studList = K12.Data.Student.SelectByIDs(e.List);

                foreach (StudentRecord stud in studList)
                {
                    if (!DicStudent.ContainsKey(stud.ID))
                    {
                        DicStudent.Add(stud.ID, stud);
                    }
                }

                allrecords.Sort(SortSLRecord);

                for (int i = 0; i < allrecords.Count; i++)
                {
                    RowData row = new RowData();
                    row.ID = allrecords[i].RefStudentID;
                    foreach (string field in e.ExportFields)
                    {
                        if (wizard.ExportableFields.Contains(field))
                        {
                            switch (field)
                            {
                                case "學年度": row.Add(field, "" + allrecords[i].SchoolYear); break;
                                case "學期": row.Add(field, "" + allrecords[i].Semester); break;
                                case "發生日期": row.Add(field, "" + allrecords[i].OccurDate.ToShortDateString()); break;
                                case "事由": row.Add(field, "" + allrecords[i].Reason); break;
                                case "時數": row.Add(field, "" + allrecords[i].Hours); break;
                                case "主辦單位": row.Add(field, "" + allrecords[i].Organizers); break;
                                case "登錄日期": row.Add(field, "" + allrecords[i].RegisterDate.ToShortDateString()); break;
                                case "備註": row.Add(field, "" + allrecords[i].Remark); break;
                            }
                        }
                    }

                    e.Items.Add(row);
                }
            };
        }

        private int SortSLRecord(SLRecord slr1, SLRecord slr2)
        {
            #region slr1String
            string slr1String = "";
            StudentRecord stud01 = DicStudent[slr1.RefStudentID];

            if (string.IsNullOrEmpty(stud01.RefClassID))
            {
                slr1String += "000000000000"; //年/班序/班級/座
            }
            else
            {
                //年
                if (stud01.Class.GradeYear.HasValue)
                {
                    slr1String += stud01.Class.GradeYear.Value.ToString();
                }
                else
                {
                    slr1String += "0";
                }

                //班序
                slr1String += stud01.Class.DisplayOrder.PadLeft(2, '0');

                //班級
                slr1String += stud01.Class.Name.PadLeft(6, '0');

                if (stud01.SeatNo.HasValue)
                {
                    slr1String += stud01.SeatNo.Value.ToString().PadLeft(3, '0');
                }
                else
                {
                    slr1String += "000";
                }

            }

            slr1String += stud01.Name.PadLeft(6, '0'); 

            #endregion

            #region slr2String
            string slr2String = "";
            StudentRecord stud02 = DicStudent[slr2.RefStudentID];

            if (string.IsNullOrEmpty(stud02.RefClassID))
            {
                slr2String += "000000000000"; //年/班序/班級/座
            }
            else
            {
                //年
                if (stud02.Class.GradeYear.HasValue)
                {
                    slr2String += stud02.Class.GradeYear.Value.ToString();
                }
                else
                {
                    slr2String += "0";
                }

                //班序
                slr2String += stud02.Class.DisplayOrder.PadLeft(2, '0');

                //班級
                slr2String += stud02.Class.Name.PadLeft(6, '0');

                if (stud02.SeatNo.HasValue)
                {
                    slr2String += stud02.SeatNo.Value.ToString().PadLeft(3, '0');
                }
                else
                {
                    slr2String += "000";
                }

            }

            slr2String += stud02.Name.PadLeft(6, '0'); 

            #endregion

            if (slr1String.CompareTo(slr2String) == 0) //同一個人時
            {
                return slr1.OccurDate.CompareTo(slr2.OccurDate);
            }
            else
            {
                return slr1String.CompareTo(slr2String);
            }
        }
    }
}
