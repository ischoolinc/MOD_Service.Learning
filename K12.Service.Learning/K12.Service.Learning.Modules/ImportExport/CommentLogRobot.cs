using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;

namespace K12.Service.Learning.Modules
{
    class CommentLogRobot
    {
        private bool Mode = false; //模式為true,就是新增資料

        private string _OldString { get; set; }

        private string _NewString { get; set; }

        private SLRecord _UDT { get; set; } //_UDT為null就是新增資料

        private SLRecord new_UDT { get; set; }

        public CommentLogRobot(SLRecord UDT)
        {
            if (UDT != null)
            {
                #region 備份修改前狀態

                _UDT = new SLRecord();
                _UDT.SchoolYear = UDT.SchoolYear;
                _UDT.Semester = UDT.Semester;

                _UDT.Hours = UDT.Hours;
                _UDT.OccurDate = UDT.OccurDate;
                _UDT.Organizers = UDT.Organizers;
                _UDT.Reason = UDT.Reason;
                _UDT.RegisterDate = UDT.RegisterDate;
                #endregion
            }
        }

        /// <summary>
        /// 新增代表UDT是null
        /// </summary>
        public void Set(SLRecord UDT)
        {
            new_UDT = UDT;
        }

        /// <summary>
        /// 是否為新增資料
        /// </summary>
        /// <returns></returns>
        public bool check()
        {
            if (_UDT == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 取得Log字串
        /// </summary>
        public string LogToString()
        {
            StringBuilder sb = new StringBuilder();
            if (_UDT == null)
            {
                #region 新增

                sb.AppendLine("");
              
                #endregion
                return sb.ToString();
            }
            else
            {
                #region 修改
                //封存分類+學號 - 不可任意修改
                sb.AppendLine("");

             
                #endregion
                return sb.ToString();
            }
        }

        /// <summary>
        /// 檢查字串是否不相等
        /// </summary>
        private bool CheckEmn(string a, string b)
        {
            if (a != b)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 檢查是否"不"為空值
        /// </summary>
        private bool CheckEpt(string a)
        {
            if (!string.IsNullOrEmpty(a))
                return true;
            else
                return false;
        }
    }
}
