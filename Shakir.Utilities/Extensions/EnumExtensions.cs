using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Shakir.Utilities.Attributes;

namespace Shakir.Utilities.Extensions
{
    public static class EnumExtensions
    { 
        /// <summary>
        /// Gets the first database code for this enumeration
        /// </summary>
        /// <param name="en">The en.</param>
        /// <param name="passThruNull">A boolean </param>
        /// <returns>Database code</returns>
        public static string DatabaseCode(this Enum en, bool passThruNull = false)
        {
            if (passThruNull && en == null)
                return string.Empty;

            var attribute = GetAttribute<DatabaseCodeAttribute>(en);
            return attribute?.Code;
        }
         
        public static Brush BrushColour(this Enum en)
        {

            var attr = GetAttribute<ColourAttribute>(en);

            if (attr == null)
                throw new ArgumentNullException("Missing ColorAttribute on enum value: " + en);

            return new SolidBrush(attr.Colour);
        }
        public static Color Colour(this Enum en)
        {
            var attr = GetAttribute<ColourAttribute>(en);

            if (attr == null)
                throw new ArgumentNullException("Missing ColorAttribute on enum value: " + en);

            return attr.Colour;
        }
        public static T ParseEnum<T>(string value) => (T)Enum.Parse(typeof(T), value, true);

        public static string Description(this Enum value)
        {
            var enumType = value.GetType();
            var field = enumType.GetField(value.ToString());
            var attributes = field.GetCustomAttributes(typeof (DescriptionAttribute), false);

            return attributes.Length == 0
                ? value.ToString()
                : ((DescriptionAttribute) attributes[0]).Description;
        }
        public static T ParseLocalisedDescription<T>(string localisedDescription, string errorMessage) where T : struct
        {
            foreach (var value in from T value in Enum.GetValues(typeof(T))
                let attr = GetAttribute<LocalisedDescriptionAttribute>((Enum)(object)value)
                where string.Equals(attr.Description, localisedDescription,
                    StringComparison.CurrentCultureIgnoreCase)
                select value)
            {
                return value;
            }

            throw new ArgumentOutOfRangeException(nameof(localisedDescription), errorMessage);
        }

        public static bool TryParseLocalisedDescription<T>(string localisedDescription, string errorMessage, out T value) where T :
            struct
        {
            try
            {
                value = ParseLocalisedDescription<T>(localisedDescription, errorMessage);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                value = default(T);
                return false;
            }
        }


        public static T FindByDatabaseCodeChecked<T>(string databaseCode) where T : struct
        {
            var findByDatabaseCodeChecked = FindByDatabaseCodeChecked<T>(databaseCode, false);
            return findByDatabaseCodeChecked ?? default(T);
        }

        public static T? FindByDatabaseCodeChecked<T>(string databaseCode, bool passThruNull) where T : struct
        {
            var val = FindByDatabaseCode<T>(databaseCode);

            if (val.HasValue)
                return val.Value;

            if (passThruNull)
                return null;

            throw new ArgumentException($"Could not find item with dbcode {databaseCode} in enum {typeof(T).Name}");
        }

        public static T? FindByDatabaseCode<T>(string databaseCode)
            where T : struct
        { 
            foreach (var value in from Enum value in Enum.GetValues(typeof(T)) from code in new[]{value.DatabaseCode()} where string.Equals(code, databaseCode, StringComparison.CurrentCultureIgnoreCase) select value)
            {
                return (T)(object)value.DatabaseCode();
            }

            return null;
        }

        public static bool HasFlag(this Enum value, Enum flagValue) =>
            ((int) (object) value & (int) (object) flagValue) != 0;

        #region Private Methods
        /// <summary>
        /// Gets the specified attribute.
        /// </summary>
        /// <typeparam name="T">Attribute derived type to locate</typeparam>
        /// <param name="enumeration">The enumeration to locate the attribute on.</param>
        /// <returns></returns>
        private static T GetAttribute<T>(Enum enumeration) where T : Attribute
        {
            var type = enumeration.GetType();
            var memInfo = type.GetMember(enumeration.ToString());

            return memInfo.Length > 0
                ? (T)memInfo[0].GetCustomAttributes(typeof(T), false).FirstOrDefault()
                : null;
        }
        #endregion
    }
}