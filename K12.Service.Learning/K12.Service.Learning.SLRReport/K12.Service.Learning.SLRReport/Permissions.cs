using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K12.Service.Learning.SLRReport
{
    class Permissions
    {
        public static string 班級服務學習統計表 { get { return "K12.Service.Learning.Modules.SLRClassTotal.cs"; } }
        public static bool 班級服務學習統計表權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[班級服務學習統計表].Executable;
            }
        }
    }
}
