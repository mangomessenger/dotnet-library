using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Services
{
    public class GroupService
    {
        private readonly RestClient _restClient = new RestClient();
        private const string Url = "http://localhost/chats/groups";
        private readonly Session _session;

        public GroupService(Session session)
        {
            _session = session;
        }

        /// <summary>
        /// 
        /// Creates a new group.
        ///
        /// See https://mangomessenger.com/methods/post/chats.groups
        /// 
        /// </summary>
        public Group CreateGroup(CreateCommunityPayload payload)
        {
            _restClient.Timeout = -1;
            var request = new RestRequest(Url, Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}\"");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Group>(content);
        }
    }
}