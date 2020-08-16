using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicesLibrary.Models;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.ChatRoute;

namespace ServicesLibrary.Services
{
    public class UserChatsService
    {
        // "http://localhost/users/"
        private static readonly string Route = $"{ApiRoot}/{Chats}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public UserChatsService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<UserChats> GetUserChatsAsync()
        {
            var response = await HttpRequest.Get(_httpClient, Route);
            return JsonConvert.DeserializeObject<UserChats>(response);
        }
    }
}