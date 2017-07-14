using System;
using System.ComponentModel.DataAnnotations;
using Shakir.Utilities.Attributes.Enums;

namespace Shakir.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class RangeIfAttribute : ConditionalValidationAttribute
    {
        #region Constructors

        public RangeIfAttribute(int minimum, int maximum, string dependentPropertyName, Relation relation,
            object dependentPropertyRequiredValue)
            : base(new RangeAttribute(minimum, maximum), dependentPropertyName, string.Empty, relation,
                dependentPropertyRequiredValue)
        {
        }

        public RangeIfAttribute(double minimum, double maximum, string dependentPropertyName, Relation relation,
            object dependentPropertyRequiredValue)
            : base(new RangeAttribute(minimum, maximum), dependentPropertyName, string.Empty, relation,
                dependentPropertyRequiredValue)
        {
        }

        public RangeIfAttribute(Type type, string minimum, string maximum, string dependentPropertyName,
            Relation relation, object dependentPropertyRequiredValue)
            : base(new RangeAttribute(type, minimum, maximum), dependentPropertyName, string.Empty, relation,
                dependentPropertyRequiredValue)
        {
        }

        public RangeIfAttribute(int minimum, int maximum, string dependentPropertyName, string secondDependentPropertyName, Relation relation,
            object dependentPropertyRequiredValue)
            : base(new RangeAttribute(minimum, maximum), dependentPropertyName, secondDependentPropertyName, relation,
                dependentPropertyRequiredValue)
        {
        }

        #endregion Constructors
    }
}
