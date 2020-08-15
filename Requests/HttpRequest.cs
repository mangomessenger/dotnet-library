using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ServicesLibrary.Requests
{
    public static class HttpRequest
    {
        public static HttpRequestMessage Post(string route, object body)
        {
            var serialize = JsonConvert.SerializeObject(body);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(route),
                Content = new StringContent(serialize, Encoding.Default, "application/json")
            };

            return request;
        }

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
    }
}