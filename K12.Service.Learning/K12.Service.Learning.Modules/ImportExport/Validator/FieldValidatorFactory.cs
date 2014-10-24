using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.DocumentValidator;
using System.Data;

namespace K12.Service.Learning.Modules
{
    class FieldValidatorFactory : IFieldValidatorFactory
    {
        #region IFieldValidatorFactory 成員

        public IFieldValidator CreateFieldValidator(string typeName, System.Xml.XmlElement validatorDescription)
        {

            switch (typeName.ToUpper())
            {
                case "STUDENTNUMBEREXISTENCE":
                    return new StudentNumberExistenceValidator();
                case "SLIDINSYSTEM":
                    return new StudentNumberRepeatValidator_up();
                case "STUDENTNUMBERREPEAT":
                    return new StudentNumberRepeatValidator();
                case "ISDECIMAL":
                    return new ISDECIMAL();
                default:
                    return null;
            }
        }
        #endregion
    }
}
