using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Services
{
    public class ChatService : IChatService
    {
        private readonly RestClient _restClient = new RestClient();
        private const string Url = "http://localhost/chats/direct-chats";
        private readonly Session _session;

        public ChatService(Session session)
        {
            _session = session;
        }

        /// <summary>
        /// 
        /// Creates a new direct chat.
        ///
        /// See https://mangomessenger.com/methods/post/chats.direct-chats
        /// 
        /// </summary>
        public IChat CreateDirectChat(CreateDirectChatPayload payload)
        {
            _restClient.Timeout = -1;
            var request = new RestRequest(Url, Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}\"");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<DirectChat>(content);
        }
    }
}