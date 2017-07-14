using System.Web;
using Shakir.Utilities.Wrappers.Interfaces;

namespace Shakir.Utilities.Wrappers
{
    public class HttpContextSessionWrapper: IHttpContextSessionWrapper
    {
        public T GetFromSession<T>(string key)
        {
            if (HttpContext.Current.Session[key] == null)
                return default(T);

            return (T)HttpContext.Current.Session[key];
        }

        public void SetInSession(string key, object value) => HttpContext.Current.Session[key] = value;
    }
}
