using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;

namespace K12.Service.Learning.Modules
{
    class ISDECIMAL : IFieldValidator
    {
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
            if (時數轉換器.IsDecimal(Value))
            {
                decimal dec = decimal.Parse(Value);

                if (時數轉換器.SentDecimalByString(Value))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
