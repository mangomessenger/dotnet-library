using RestSharp;
using ServicesLibrary.Models;

namespace ServicesLibrary.Requests
{
    public static class PostRequests
    {
        public static RestRequest AuthorizedPostRequest(Session session)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
    }
}