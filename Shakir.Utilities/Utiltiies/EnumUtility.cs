using System;
using System.Linq;
using Shakir.Utilities.Attributes;
using static System.Enum;

namespace Shakir.Utilities.Utiltiies
{
    public static class EnumUtility
    {   
        public static T GetEnum<T>(this int number)
        {
            if (IsDefined(typeof(T), number))
            {
                return (T)ToObject(typeof(T), number);
            }
            throw new ArgumentException($"{typeof(T)} does not contain a value member = {number}");
        }
        public static T GetEnum<T>(string name) where T : struct
        {
            if (!IsDefined(typeof(T), name))
                throw new ArgumentException($"{typeof(T)} does not contain a value member = {name}");

            TryParse(name, out T outputEnumType);
            return outputEnumType;
        }
    }
}
