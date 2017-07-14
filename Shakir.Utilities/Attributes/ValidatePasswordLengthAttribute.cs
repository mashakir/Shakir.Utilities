using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Security;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' must be at least {1} characters long.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(DefaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentUICulture, ErrorMessageString,
                name, _minCharacters);
        }

        public override bool IsValid(object value)
            => (value != null && ((string)value).Length >= _minCharacters);
    }
}
