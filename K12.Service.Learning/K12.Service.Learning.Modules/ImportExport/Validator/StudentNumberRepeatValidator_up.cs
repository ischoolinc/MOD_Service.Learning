using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using K12.Data;
using System.Data;

namespace K12.Service.Learning.Modules
{
    class StudentNumberRepeatValidator_up : IFieldValidator
    {
        List<string> list = new List<string>();
        public StudentNumberRepeatValidator_up()
        {
            list = GetSLList();
        }

        #region IFieldValidator 成員

        public string Correct(string Value)
        {
            return Value;
        }

        public string ToString(string template)
        {
            return template;
        }

        public bool Validate(string Value)
        {
            if (list.Contains(Value)) //包含此系統編號
            {
                return false;

            }
            return true;
        }

        /// <summary>
        /// 取得學生學號 vs 系統編號
        /// </summary>
        private List<string> GetSLList()
        {
            FISCA.Data.QueryHelper _queryHelper = new FISCA.Data.QueryHelper();

            List<string> list_j = new List<string>();
            //取得比對序

            DataTable dt = _queryHelper.Select("select uid from $k12.service.learning.record");
            foreach (DataRow row in dt.Rows)
            {
                string slUID = "" + row[0];

                if (string.IsNullOrEmpty(slUID))
                    continue;

                if (!list_j.Contains(slUID))
                {
                    list_j.Add(slUID);
                }
            }
            return list_j;

        }

        #endregion
    }
}
