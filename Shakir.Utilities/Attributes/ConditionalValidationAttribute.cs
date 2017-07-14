using System;
using System.ComponentModel.DataAnnotations;
using Shakir.Utilities.Attributes.Enums;
using Shakir.Utilities.Helpers;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ConditionalValidationAttribute : ValidationAttribute
    {
        #region Fields

        private const string NotCombarableValueObjectErrorMessage = "The value to validate should be comparable.";
        protected readonly ValidationAttribute ValidationAttribute;

        #endregion Fields

        #region Properties

        public string DependentPropertyName { get; set; }

        public string SecondDependentPropertyName { get; set; }

        public object DependentPropertyRequiredValue { get; set; }

        public Relation Relation { get; set; }

        #endregion Properties

        #region Constructors

        protected ConditionalValidationAttribute(ValidationAttribute validationAttribute, string dependentPropertyName, string secondDependentPropertyName,
            Relation relation, object dependentPropertyRequiredValue)
        {
            ValidationAttribute = validationAttribute;
            DependentPropertyName = dependentPropertyName;
            SecondDependentPropertyName = secondDependentPropertyName;
            DependentPropertyRequiredValue = dependentPropertyRequiredValue;
            Relation = relation;
        }

        #endregion Constructors

        #region Protected methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var count = 0;
            ValidationResult result;
            do
            {
                var dependentPropertyName = count > 0 ? SecondDependentPropertyName : DependentPropertyName;

                var dependentPropertyActualValue = PropertyHelper.GetPropertyValue(validationContext.ObjectInstance, dependentPropertyName);
                var shouldCallValidation = GetRelationResult(dependentPropertyActualValue, Relation,
                    DependentPropertyRequiredValue);

                if (shouldCallValidation)
                {
                    var innerResult = ValidationAttribute.GetValidationResult(value, validationContext);

                    result = innerResult == ValidationResult.Success ||
                             (string.IsNullOrEmpty(ErrorMessage) && string.IsNullOrEmpty(ErrorMessageResourceName))
                        ? innerResult
                        : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
                else
                {
                    result = ValidationResult.Success;
                }

                if (count > 0) break;
                count++;
            } while (!string.IsNullOrEmpty(SecondDependentPropertyName) && result != ValidationResult.Success);


            return result;
        }

        protected bool GetRelationResult(object actualValue, Relation relation, object requiredValue)
        {
            bool result;

            switch (relation)
            {
                case Relation.LessThan:
                case Relation.LessThanOrEqual:
                case Relation.GreaterThan:
                case Relation.GreaterThanOrEqual:
                    result = GetComparableResult(actualValue, relation, requiredValue);
                    break;
                case Relation.Equal:
                case Relation.NotEqual:
                    result = GetEquatableResult(actualValue, relation, requiredValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("relation");
            }

            return result;
        }

        #endregion Protected methods

        #region Private methods

        private static bool GetEquatableResult(object actualValue, Relation relation, object requiredValue)
        {
            bool result;

            switch (relation)
            {
                case Relation.Equal:
                    result = (actualValue == null && requiredValue == null) ||
                             (actualValue != null && actualValue.Equals(requiredValue));
                    break;
                case Relation.NotEqual:
                    result = (actualValue == null && requiredValue != null) ||
                             (actualValue != null && !actualValue.Equals(requiredValue));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("relation");
            }

            return result;
        }

        private static bool GetComparableResult(object actualValue, Relation relation, object requiredValue)
        {
            bool result;

            if (actualValue == null)
            {
                switch (relation)
                {
                    case Relation.LessThan:
                        result = requiredValue != null;
                        break;
                    case Relation.LessThanOrEqual:
                        result = true;
                        break;
                    case Relation.GreaterThan:
                        result = false;
                        break;
                    case Relation.GreaterThanOrEqual:
                        result = requiredValue == null;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("relation");
                }
            }
            else
            {
                var comparableActualValue = actualValue as IComparable;
                if (comparableActualValue == null)
                {
                    throw new InvalidOperationException(NotCombarableValueObjectErrorMessage);
                }

                var compareResult = comparableActualValue.CompareTo(requiredValue);
                switch (relation)
                {
                    case Relation.LessThan:
                        result = compareResult < 0;
                        break;
                    case Relation.LessThanOrEqual:
                        result = compareResult <= 0;
                        break;
                    case Relation.GreaterThan:
                        result = compareResult > 0;
                        break;
                    case Relation.GreaterThanOrEqual:
                        result = compareResult >= 0;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return result;
        }

        #endregion Private methods
    }
}
