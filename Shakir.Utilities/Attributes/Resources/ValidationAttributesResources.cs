namespace Shakir.Utilities.Attributes.Resources
{
    internal class ValidationAttributesResources
    {
        internal static string RelationAttributeLessThanValidationError => "The '{0}' field should be less than field '{1}'.";

        internal static string RelationAttributeLessThanOrEqualValidationError => "The '{0}' field should be less than or equal to field '{1}'.";

        internal static string RelationAttributeGreaterThanValidationError => "The '{0}' field should be greater than field '{1}'.";

        internal static string RelationAttributeGreaterThanOrEqualValidationError => "The '{0}' field should be greater than or equal to field '{1}'.";

        internal static string ColorAttributeValidColorRequired => "The '{0}' field should be a valid color name or valid color code.";

        internal static string NotAllowedAttributeValidationError => "The '{0}' field should be empty.";

        internal static string MustNotEqualAttributeDefaultError => "The field {0} cannot has the same value as field {1}";

        internal static string EqualToIgnoreCaseAttributeError => "The field {0} should be the same value as field {1}";
    }
}
