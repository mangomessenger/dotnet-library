using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using static ServicesLibrary.Routes.ApiRoutes;
using static ServicesLibrary.Routes.ChatRoutes;

namespace ServicesLibrary.Services
{
    public class ChannelService
    {
        // "http://localhost/chats/channels/"
        private static readonly string Route = $"{ApiRoute}/{Chats}/{Channels}/";
        private readonly RestClient _restClient = new RestClient(Route);
        private readonly Session _session;

        public ChannelService(Session session)
        {
            _session = session;
        }
        
        /// <summary>
        /// 
        /// Creates a new channel.
        ///
        /// See https://mangomessenger.com/methods/post/chats.channels
        /// 
        /// </summary>
        public Channel CreateChannel(CreateCommunityPayload payload)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Channel>(content);
        }
    }
}