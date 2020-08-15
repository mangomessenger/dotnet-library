using RestSharp;
using ServicesLibrary.Models;

namespace ServicesLibrary.Requests
{
    public static class ApiRequest
    {
        public static RestRequest Post(Session session)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
        
        public static RestRequest Post(string route)
        {
            var request = new RestRequest(route, Method.POST);
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestRequest Get(Session session)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
        
        public static RestRequest Get(string route, Session session)
        {
            var request = new RestRequest(route, Method.GET);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestRequest Put(string route, Session session)
        {
            var request = new RestRequest(route, Method.PUT);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestRequest Delete(string route, Session session)
        {
            var request = new RestRequest(route, Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
    }
}