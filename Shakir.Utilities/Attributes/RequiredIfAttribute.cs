using System;
using System.ComponentModel.DataAnnotations;
using Shakir.Utilities.Attributes.Enums;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RequiredIfAttribute : ConditionalValidationAttribute
    {
        public RequiredIfAttribute(string dependentPropertyName, Relation relation, object dependentPropertyRequiredValue)
            : base(new RequiredAttribute(), dependentPropertyName, string.Empty, relation, dependentPropertyRequiredValue)
        {
        }
    }
}
