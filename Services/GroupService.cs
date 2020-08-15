using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using static ServicesLibrary.Routes.ApiRoutes;
using static ServicesLibrary.Routes.ChatRoutes;

namespace ServicesLibrary.Services
{
    public class GroupService
    {
        private static readonly string Route = $"{ApiRoute}/{Chats}/{Groups}/";
        private readonly RestClient _restClient = new RestClient(Route);
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
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Group>(content);
        }
    }
}