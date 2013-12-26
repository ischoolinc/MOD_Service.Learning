using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Data;
using System.Data;
using FISCA.UDT;

namespace K12.Service.Learning.Modules
{
    static public class tool
    {
        static public QueryHelper _Q = new QueryHelper();

        static public AccessHelper _A = new AccessHelper();


        static public string TableName = "\"$K12.Service.Learning.Record\"";
        /// <summary>
        /// 取得系統內所有主辦單位的交集資料
        /// </summary>
        static public List<string> GetOrganizersTable()
        {
            DataTable dt = _Q.Select("select organizers from " + TableName.ToLower() + " group by organizers ORDER by organizers");

            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string organizers = "" + row["organizers"];
                if (!string.IsNullOrEmpty(organizers))
                {
                    list.Add(organizers);
                }
            }
            return list;
        }
    }
}
