using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12.SL.OrganizersStatistics
{
    class SetupObj
    {
        /// <summary>
        /// 主辦單位/或事由
        /// </summary>
        public bool IsOrganizer { get; set; }

        /// <summary>
        /// 學年度學期/或日期
        /// </summary>
        public bool IsSchoolYear { get; set; }

        /// <summary>
        /// 學年度
        /// </summary>
        public int SchoolYear { get; set; }

        /// <summary>
        /// 學期
        /// </summary>
        public int Semester { get; set; }

        /// <summary>
        /// 開始日期
        /// </summary>
        public DateTime dtStart { get; set; }

        /// <summary>
        /// 結束日期
        /// </summary>
        public DateTime dtEnd { get; set; }




    }
}
