using System.Web.Routing;

namespace Shakir.Utilities.Extensions
{
    public static class RouteValueDictionaryExtensions
    {
        public static RouteValueDictionary WithValue(this RouteValueDictionary dictionary, string key, object value)
        {
            dictionary.Add(key, value);
            return dictionary;
        }
    }
}
