using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12.SL.OrganizersStatistics
{
    class Permissions
    {
        public static string 主辦單位與事由統計 { get { return "Service.Learning.OrganizersStatistics.Form001.cs"; } }

        public static bool 主辦單位與事由統計權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[主辦單位與事由統計].Executable;
            }
        }
    }
}
