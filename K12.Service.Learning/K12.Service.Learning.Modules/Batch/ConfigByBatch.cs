using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using K12.Data;

namespace K12.Service.Learning.Modules
{
    /// <summary>
    /// 使用者條件內容
    /// </summary>
    class ConfigByBatch
    {
        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        ///  事由
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 主辦單位
        /// </summary>
        public string Organizers { get; set; }
        /// <summary>
        /// 時數
        /// </summary>
        public decimal Hours { get; set; }
        /// <summary>
        /// 時數
        /// </summary>
        public 服務學習大小 checkNow { get; set; }

        ///// <summary>
        ///// 比對資料
        ///// </summary>
        //public CheckType type { get; set; }

        ///// <summary>
        ///// 年級
        ///// </summary>
        //public string GradeYear { get; set; }

        public bool SelectDayType { get; set; }

        public ConfigByBatch()
        {
            StartTime = DateTime.Today;
            EndTime = DateTime.Today;
            Reason = "";
            Organizers = "";
            Hours = 0;
            //type = CheckType.大於;
            //GradeYear = "";
            SelectDayType = true;

        }
    }

    //enum CheckType { 大於, 等於, 小於 }
}
