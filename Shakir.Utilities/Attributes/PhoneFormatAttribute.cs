using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Shakir.Utilities.Attributes.Resources;

namespace Shakir.Utilities.Attributes
{
    public class PhoneFormatAttribute : ValidationAttribute
    {
        #region Properties
        /// <summary>
        /// Gets or sets the property name of default country.
        /// </summary>
        public string DefaultCountryPropertyName { get; set; }
        /// <summary>
        /// Gets or sets the property name of selected country.
        /// </summary>
        public string SelectedCountryPropertyName { get; set; }

        public string PhoneFormatRegularExpression { get; set; }
        #endregion

        #region Protected Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(ErrorMessage);

            var instance = validationContext.ObjectInstance;
            var type = instance.GetType();
            var selectedCoutnryIdInstance = type.GetProperty(SelectedCountryPropertyName);
            string selectedCountryId = null;

            if (selectedCoutnryIdInstance != null)
            {
                selectedCountryId = selectedCoutnryIdInstance.GetValue(instance, null).ToString();
            }
           
            if (!string.IsNullOrEmpty(selectedCountryId))
            {
                var defaultCountryInstance = type.GetProperty(DefaultCountryPropertyName);
                var defaultCountryId = defaultCountryInstance.GetValue(instance, null).ToString();
                if (!string.IsNullOrEmpty(defaultCountryId) && defaultCountryId != "0")
                    defaultCountryId = defaultCountryInstance.GetValue(instance, null).ToString();
                  
                if (!string.IsNullOrEmpty(defaultCountryId) && (selectedCountryId == defaultCountryId))
                {
                    if (string.IsNullOrEmpty(PhoneFormatRegularExpression))
                        PhoneFormatRegularExpression = RegularExpressionResources.PhoneFormatUkOnly;

                    return !Regex.IsMatch(value.ToString(), PhoneFormatRegularExpression)
                        ? new ValidationResult(ErrorMessage)
                        : ValidationResult.Success;
                }
            }

            return !Regex.IsMatch(value.ToString(), RegularExpressionResources.NumberOnly)
                ? new ValidationResult(ErrorMessage)
                : ValidationResult.Success;
        }

        #endregion 
    }
}
