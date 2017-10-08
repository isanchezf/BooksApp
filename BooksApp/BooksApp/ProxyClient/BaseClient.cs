using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BooksApp.ProxyClient
{
    public class BaseClient<T> where T : class, new()
    {
        protected string Url;
        private string _authorizationKey;
        private readonly IHttpClient _httpClient;

        public BaseClient(string service, IHttpClient httpClient)
        {
            Url = Path.Combine("http://fakeapibooks.azurewebsites.net/Api",service);
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _httpClient.GetStringAsync(Url, _authorizationKey);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }

        public async Task<T> Add(T entity)
        {
            var response = await _httpClient.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(entity),
                    Encoding.UTF8, "application/json"),
                _authorizationKey
                );

            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
