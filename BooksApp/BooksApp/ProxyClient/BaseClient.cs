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

        public BaseClient(string service)
        {
            Url = Path.Combine("http://fakeapibooks.azurewebsites.net/Api",service);
        }

        protected async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            if (string.IsNullOrEmpty(_authorizationKey))
            {
                //_authorizationKey = await client.GetStringAsync(Url + "login");
                //_authorizationKey = JsonConvert.DeserializeObject<string>(_authorizationKey);
                //client.DefaultRequestHeaders.Add("Authorization", _authorizationKey);
            }
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var client = await GetClient();
            var result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(result);
        }

        public async Task<T> Add(T entity)
        {
            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(entity),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<T>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
