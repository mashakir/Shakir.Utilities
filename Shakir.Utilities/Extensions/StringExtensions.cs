using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Shakir.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string ToLowerAndRemoveSpaces(this string value) => value.ToLower().Replace(" ", "");

        public static string ToLowerAndTrim(this string value) => value.ToLower().Trim();

        public static string TrimText(this string originalString, int maxLength, string ending)
        {
            var trimmedString = string.Empty;

            if (string.IsNullOrEmpty(originalString) || maxLength < 0) return trimmedString;
            // Trim the string (on condition that maxLength is OK)
            trimmedString = (originalString.Length > maxLength)
                ? originalString.Substring(0, maxLength)
                : originalString;

            // We continue processing if the original string has been trimmed - othersise return the original string
            // (e.g. when maxLength was greter than the original string's length)
            if (trimmedString == originalString) return trimmedString;
            // Split the string into words
            var aWords = trimmedString.Split(' ');
            //  Throw away the last (cut) word
            trimmedString = String.Join(" ", aWords, 0, aWords.Length - 1);

            // Ensure that the last word does not have any of the characters at the end
            // (e.g. if last word ends with ',' then we need to remove this ',')

            // Remove the last character until it's OK
            while (trimmedString.Length != 0 &&
                   IllegalTrimmedStringChars.IndexOf(trimmedString.Substring(trimmedString.Length - 1),
                       StringComparison.Ordinal) != -1)
            {
                trimmedString = trimmedString.Remove(trimmedString.Length - 1, 1);
            }

            // Usually '...' is added to the end
            trimmedString += ending;

            return trimmedString;
        }

        public static string MakeValidFileName(this string name)
        { 
            var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            var invalidRegStr = $@"([{invalidChars}]*\.+$)|([{invalidChars}]+)";

            return Regex.Replace(name, invalidRegStr, "");
        }
        public static string RemoveSpecialCharacters(this string text) => Regex.Replace(text, @"[^0-9a-zA-Z]+", "");

        /// <summary>
        /// Converts a string to the given data type.
        /// </summary>
        /// <typeparam name="T">Type to convert to.</typeparam>
        /// <param name="value">Value.</param>
        /// <returns></returns>
        public static T? ConvertTo<T>(this string value) where T : struct
        {
            try
            { 
                return (T?) Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return null;
            }
        }
        
        public static string UrlPathEncode(this string input)
        {
            if (input == null)
                return null;

            var result = HttpUtility.UrlPathEncode(input);

            if (result.Length > 0)
                result = InvalidChars.Keys.Aggregate(result, (current, @char) => current.Replace(@char.ToString(CultureInfo.InvariantCulture), InvalidChars[@char]));

            return result;
        }

        #region Private Method

        private const string IllegalTrimmedStringChars = " `~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?";
        private static readonly IDictionary<char, string> InvalidChars = new Dictionary<char, string>
        {
            {'.', "%7C"},
            {'>', "%3E"},
            {'<', "%3C"},
            {'(', "%28"},
            {')', "%29"},
        };
        #endregion
    }
}
