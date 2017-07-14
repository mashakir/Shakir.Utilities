using System;
using System.ComponentModel.DataAnnotations;

namespace Shakir.Utilities.Attributes
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var dt = (DateTime)value;

            return dt.Date >= DateTime.Now.Date;
        }
    }
}
