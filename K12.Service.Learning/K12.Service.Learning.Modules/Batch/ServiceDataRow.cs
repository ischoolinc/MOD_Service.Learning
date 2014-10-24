using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;

namespace K12.Service.Learning.Modules
{
    class ServiceDataRow : System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// 服務學習主要物件
        /// </summary>
        public SLRecord _slr { get; set; }

        /// <summary>
        /// 學生
        /// </summary>
        public StudentRecord _student { get; set; }

        /// <summary>
        /// 是否資料被更動過
        /// </summary>
        public bool IsChange { get; set; }

        #region 學生基本資料

        /// <summary>
        /// 學生系統編號
        /// </summary>
        public string StudentID
        {
            get
            {
                if (_student != null)

                    return _student.ID;
                else
                    return "";
            }
        }

        /// <summary>
        /// 班級
        /// </summary>
        public string ClassName
        {
            get
            {
                if (_student.Class != null)
                    return _student.Class.Name;
                else
                    return "";

            }
        }

        /// <summary>
        /// 座號
        /// </summary>
        public string SeatNo
        {
            get
            {
                if (_student.SeatNo.HasValue)
                    return _student.SeatNo.Value.ToString();
                else
                    return "";
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName
        {
            get
            {
                return _student.Name;
            }
        }

        /// <summary>
        /// 學號
        /// </summary>
        public string StudentNumber
        {
            get
            {
                return _student.StudentNumber;
            }
        }

        #endregion

        #region 服務學習物件

        /// <summary>
        /// 發生日期
        /// </summary>
        public string OccurDate
        {
            get
            {
                return _slr.OccurDate.ToShortDateString();
            }
            set
            {
                DateTime dt;
                if (DateTime.TryParse(value, out dt))
                {
                    IsChange = true;
                    _slr.OccurDate = dt;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("OccurDate"));
                }
                //如果Parse失敗,資料就不修改
            }
        }

        /// <summary>
        /// 事由
        /// </summary>
        public string Reason
        {
            get
            {
                return _slr.Reason;
            }
            set
            {
                IsChange = true;
                _slr.Reason = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Reason"));
            }
        }

        /// <summary>
        /// 時數
        /// </summary>
        public decimal Hours
        {
            get
            {
                return _slr.Hours;
            }
            set
            {
                IsChange = true;
                _slr.Hours = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Hours"));
            }
        }

        /// <summary>
        /// 主辦單位
        /// </summary>
        public string Organizers
        {
            get
            {
                return _slr.Organizers;
            }
            set
            {
                IsChange = true;
                _slr.Organizers = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Organizers"));
            }
        }

        /// <summary>
        /// 校內校外
        /// </summary>
        public string InternalAndExternal
        {
            get
            {
                return _slr.InternalOrExternal;
            }
            set
            {
                IsChange = true;
                _slr.InternalOrExternal = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("InternalAndExternal"));
            }
        }

        /// <summary>
        /// 學年度
        /// </summary>
        public int SchoolYear
        {
            get
            {
                return _slr.SchoolYear;
            }
            set
            {
                IsChange = true;
                _slr.SchoolYear = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SchoolYear"));
            }
        }

        /// <summary>
        /// 學期
        /// </summary>
        public int Semester
        {
            get
            {
                return _slr.Semester;
            }
            set
            {
                IsChange = true;
                _slr.Semester = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Semester"));
            }
        }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark
        {
            get
            {
                return _slr.Remark;
            }
            set
            {
                IsChange = true;
                _slr.Remark = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Remark"));
            }
        }

        /// <summary>
        /// 登錄日期
        /// </summary>
        public string RegisterDate
        {
            get
            {
                return _slr.RegisterDate.ToShortDateString();
            }
            set
            {
                DateTime dt;
                if (DateTime.TryParse(value, out dt))
                {
                    IsChange = true;
                    _slr.RegisterDate = dt;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("RegisterDate"));
                }
                //如果Parse失敗,資料就不修改
            }
        }

        #endregion

        public ServiceDataRow(StudentRecord student, SLRecord slr)
        {
            IsChange = false;
            _student = student;
            _slr = slr;
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    }
}
