using System.Threading.Tasks;

namespace Shakir.Utilities.Wrappers.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<T> GetAsync<T>(string baseUrl, string mediaType, string action);
        Task<T> PostAsync<T,TBody>(string baseUrl, string mediaType, string action, TBody bodyContent);
    }
}
