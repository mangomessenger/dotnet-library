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
    public class ChannelService: IChatService<Channel>
    {
        // "http://localhost/chats/channels/"
        private static readonly string Route = $"{ApiRoot}/{Chats}/{Channels}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public ChannelService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<Channel> CreateChatAsync(CreateCommunityPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route, payload);
            return JsonConvert.DeserializeObject<Channel>(response);
        }
    }
}