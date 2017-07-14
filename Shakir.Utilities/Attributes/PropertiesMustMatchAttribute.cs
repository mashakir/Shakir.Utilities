using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class PropertiesMustMatchAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' and '{1}' are not matched.";

        public PropertiesMustMatchAttribute(string originalProperty, string confirmProperty)
            : base(DefaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty { get; }
        public string OriginalProperty { get; }

        public override object TypeId { get; } = new object();

        public override string FormatErrorMessage(string name)
            => string.Format(CultureInfo.CurrentUICulture, ErrorMessageString, OriginalProperty, ConfirmProperty);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var properties = TypeDescriptor.GetProperties(value);
            var originalValue = properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            var confirmValue = properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            return Equals(originalValue, confirmValue) ? ValidationResult.Success : new ValidationResult(ErrorMessage);
        }
    }
}
