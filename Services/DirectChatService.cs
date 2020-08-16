using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
    public class DirectChatService
    {
        // "http://localhost/chats/direct-chats/"
        private static readonly string Route = $"{ApiRoot}/{Chats}/{DirectChats}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public DirectChatService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }
        
        public async Task<DirectChat> CreateChatAsync(CreateDirectChatPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route, payload);
            return JsonConvert.DeserializeObject<DirectChat>(response);
        }
    }
}