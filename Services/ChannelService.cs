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
    public class ChannelService
    {
        // "http://localhost/chats/channels/"
        private static readonly string Route = $"{ApiRoot}/{Chats}/{Channels}/";
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
            var request = ApiRequest.Post(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Channel>(content);
        }
    }
}