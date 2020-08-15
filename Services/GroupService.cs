using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.ChatRoute;

namespace ServicesLibrary.Services
{
    public class GroupService : IChatService<Group>
    {
        private static readonly string Route = $"{ApiRoot}/{Chats}/{Groups}/";
        private readonly RestClient _restClient = new RestClient(Route);
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Session _session;

        public GroupService(Session session)
        {
            _session = session;
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", _session.Tokens.AccessToken);
        }

        public Group CreateChat(CreateCommunityPayload payload)
        {
            var request = RestSharpRequest.Post(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Group>(content);
        }

        public async Task<Group> CreateChatAsync(CreateCommunityPayload payload)
        {
            var json = JsonConvert.SerializeObject(payload);
            var uri = new Uri(Route);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, data);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Group>(responseBody);
        }
    }
}