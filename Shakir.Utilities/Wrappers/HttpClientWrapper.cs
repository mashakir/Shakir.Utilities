using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shakir.Utilities.Wrappers.Interfaces;

namespace Shakir.Utilities.Wrappers
{
    public class HttpClientWrapper : HttpClient, IHttpClientWrapper
    {
        private HttpClient _httpClient;
        private HttpClient HttpClientInstance => _httpClient ?? (_httpClient = new HttpClient());

        public async Task<T> GetAsync<T>(string baseUrl, string mediaType, string action)
        {
            HttpClientInstance.BaseAddress = new Uri(baseUrl);
            HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
            HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            var response = await HttpClientInstance.GetAsync(action);
            var strResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(strResponse);
        }

        public async Task<T> PostAsync<T, TBody>(string baseUrl, string mediaType, string action, TBody bodyContent)
        {
            HttpClientInstance.BaseAddress = new Uri(baseUrl);
            HttpClientInstance.DefaultRequestHeaders.Accept.Clear();
            HttpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            var content = new ObjectContent<TBody>(bodyContent, new JsonMediaTypeFormatter());
            var response = await HttpClientInstance.PostAsync(action, content);
            var strResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(strResponse);
        }
    }
}
