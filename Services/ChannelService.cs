using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Services
{
    public class ChannelService
    {
        private readonly RestClient _restClient = new RestClient();
        private const string Url = "http://localhost/chats/channels/";
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
            _restClient.Timeout = -1;
            var request = new RestRequest(Url, Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}\"");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Channel>(content);
        }
    }
}