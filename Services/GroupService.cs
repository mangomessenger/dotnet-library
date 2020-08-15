using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Chat;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.ChatRoute;
using RestRequest = ServicesLibrary.Requests.RestRequest;

namespace ServicesLibrary.Services
{
    public class GroupService
    {
        private static readonly string Route = $"{ApiRoot}/{Chats}/{Groups}/";
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
            var request = RestRequest.Post(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Group>(content);
        }
    }
}