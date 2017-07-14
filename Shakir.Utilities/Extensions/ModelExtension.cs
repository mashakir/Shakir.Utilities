using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web.UI;

namespace Shakir.Utilities.Extensions
{
    public static class ModelExtension
    {
        public static string Serialize(this object o)
        {
            using (var sw = new StringWriter())
            {
                var formatter = new LosFormatter();
                formatter.Serialize(sw, o);

                return sw.ToString();
            }
        }

        public static T Deserialize<T>(this string data)
        {  
            var formatter = new LosFormatter();
            return (T) formatter.Deserialize(data);
        }
        public static T DeepClone<T>(this T a)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
