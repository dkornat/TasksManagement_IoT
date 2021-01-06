using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TasksManagement.Mobile.Helpers;

namespace TasksManagement.Mobile.RestClient
{
    public class TasksManagementClient<T>
    {
        private const string WebServiceURL = Secrets.WebApiURL;
        private const string Key = Secrets.ApiKey;
        HttpClient _httpClient = new HttpClient();

        public TasksManagementClient()
        {
            _httpClient.DefaultRequestHeaders.Add("ApiKey", Key);
        }

        public async Task<IEnumerable<T>> GetAllItems(string uri)
        {
            try
            {
                var json = await _httpClient.GetStringAsync(WebServiceURL + uri);
                var results = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return results;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<string> CreateObject(T objectToCreate, string uri)
        {
            try
            {
                var json = JsonConvert.SerializeObject(objectToCreate);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(WebServiceURL + uri, data);
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
