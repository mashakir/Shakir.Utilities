namespace Shakir.Utilities.Helpers.Interfaces
{
    public interface IAspNetCacheHelper
    {
        void Add<T>(T o, string key, int expirationInMinutes);
        void Clear(string key);
        bool Exists(string key);
        bool Get<T>(string key, out T value);
    }
}
