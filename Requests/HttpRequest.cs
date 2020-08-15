using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServicesLibrary.Requests
{
    public static class HttpRequest
    {
        public static HttpRequestMessage Get(string route, object body)
        {
            var payload = JsonConvert.SerializeObject(body);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(route),
                Content = new StringContent(payload, Encoding.Default, "application/json")
            };

            return request;
        }

        public static async Task<HttpResponseMessage> Post(HttpClient client, string route, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var uri = new Uri(route);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, data);
            return response;
        }
        
        public static async Task<HttpResponseMessage> Put(HttpClient client, string route, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var uri = new Uri(route);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(uri, data);
            return response;
        }
        
        public static async Task<HttpResponseMessage> Delete(HttpClient client, string route)
        {
            var uri = new Uri(route);
            var response = await client.DeleteAsync(uri);
            return response;
        }
        
        public static async Task<HttpResponseMessage> Get(HttpClient client, string route)
        {
            var uri = new Uri(route);
            var response = await client.GetAsync(uri);
            return response;
        }
    }
}