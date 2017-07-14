namespace Shakir.Utilities.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToStringAndRemoveDecimals(this decimal value) => $"{value}";

        public static decimal ConditionalFlipSign(this decimal val, bool doFlip) => doFlip
            ? (val < 0 ? val * -1 : -val)
            : val;

        public static bool IsOppositeSignTo(this decimal val, decimal other) => val < 0 && other > 0 || val > 0 && other < 0;
         
    }
}
