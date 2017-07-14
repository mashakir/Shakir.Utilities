using System;
using System.ComponentModel.DataAnnotations;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PastDateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var dt = Convert.ToDateTime(value);
            return dt.Date < DateTime.Now.Date;
        }
    }
}
