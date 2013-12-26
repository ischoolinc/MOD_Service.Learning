using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12.SL.OrganizersStatistics
{
    class ValueObj
    {
        /// <summary>
        /// 統計人數
        /// </summary>
        public List<string> StudentList = new List<string>();

        /// <summary>
        /// 人次是重複的學生次數
        /// </summary>
        public int 人次 { get; set; }

        /// <summary>
        /// 此事由被服務了多少小時
        /// </summary>
        public decimal 總時數 { get; set; }


    }
}
