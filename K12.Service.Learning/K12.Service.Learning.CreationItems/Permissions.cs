using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12.Service.Learning.CreationItems
{
    class Permissions
    {
        public static string 服務學習線上開設 { get { return "K12.Service.Learning.CreationItems.1.cs"; } }
        public static bool 服務學習線上開設權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[服務學習線上開設].Executable;
            }
        }
        public static string 服務學習記錄卡 { get { return "K12.Service.Learning.CreationItems.2.cs"; } }
        public static bool 服務學習記錄卡權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[服務學習記錄卡].Executable;
            }
        }
        
    }
}
