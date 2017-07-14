using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Shakir.Utilities.Attributes.Resources;

namespace Shakir.Utilities.Attributes
{
    public class DateFormatValidatorAttribute : ValidationAttribute
    {
        public string DateFormat { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var dateTime = value as DateTime?;
            if (dateTime != null)
                return true;

            try
            {
                if (string.IsNullOrEmpty(DateFormat))
                    DateFormat = RegularExpressionResources.DateFormat;

                DateTime.ParseExact(value.ToString(), DateFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                return false;
            }

            return true;
        }
    }
}
