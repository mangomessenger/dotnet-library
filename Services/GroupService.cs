using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        private readonly HttpClient _httpClient = new HttpClient();

        public GroupService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<Group> CreateChatAsync(CreateCommunityPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Group>(responseBody);
        }
    }
}