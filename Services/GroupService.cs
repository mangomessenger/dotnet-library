using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.ChatRoute;

namespace ServicesLibrary.Services
{
    public class GroupService
    {
        private static readonly string Route = $"{ApiRoot}/{Chats}/{Groups}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public GroupService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<Group> CreateGroupAsync(CreateCommunityPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route, payload);
            return JsonConvert.DeserializeObject<Group>(response);
        }
    }
}