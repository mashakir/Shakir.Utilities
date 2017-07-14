using System.ComponentModel.DataAnnotations;

namespace Shakir.Utilities.Attributes
{
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool) value;
        }
    }
}
