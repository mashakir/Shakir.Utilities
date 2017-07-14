namespace Shakir.Utilities.Wrappers.Interfaces
{
    public interface IHttpContextSessionWrapper
    {
        T GetFromSession<T>(string key);
        void SetInSession(string key, object value);
    }
}
