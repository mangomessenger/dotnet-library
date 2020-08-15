using RestSharp;
using ServicesLibrary.Models;

namespace ServicesLibrary.Requests
{
    public static class RestRequest
    {
        public static RestSharp.RestRequest Post(Session session)
        {
            var request = new RestSharp.RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
        
        public static RestSharp.RestRequest Post(string route)
        {
            var request = new RestSharp.RestRequest(route, Method.POST);
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestSharp.RestRequest Get(Session session)
        {
            var request = new RestSharp.RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
        
        public static RestSharp.RestRequest Get(string route, Session session)
        {
            var request = new RestSharp.RestRequest(route, Method.GET);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestSharp.RestRequest Put(string route, Session session)
        {
            var request = new RestSharp.RestRequest(route, Method.PUT);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }

        public static RestSharp.RestRequest Delete(string route, Session session)
        {
            var request = new RestSharp.RestRequest(route, Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            return request;
        }
    }
}