using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.ChatRoute;

namespace ServicesLibrary.Services
{
    public class ChatService
    {
        // "http://localhost/chats/direct-chats/"
        private static readonly string Route = $"{ApiRoot}/{Chats}/{DirectChats}/";
        private readonly RestClient _restClient = new RestClient(Route);
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
        public DirectChat CreateDirectChat(CreateDirectChatPayload payload)
        {
            var request = ApiRequest.Post(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<DirectChat>(content);
        }
    }
}