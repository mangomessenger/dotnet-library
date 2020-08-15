﻿using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Models;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.UserRoute;

namespace ServicesLibrary.Services
{
    public class UserService
    {
        // "http://localhost/users/"
        private static readonly string Route = $"{ApiRoot}/{Users}/";
        private readonly RestClient _restClient = new RestClient(Route);
        private readonly Session _session;

        public UserService(Session session)
        {
            _session = session;
        }
        
        public User GetUserInfo(string username)
        {
            var request = RestSharpRequest.Get(Route + username, _session);
            var response = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<User>(response);
        }
    }
}