﻿using Newtonsoft.Json;
using ServicesLibrary.Models;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST endpoint: auth/signIn
    /// NOTE: Consider to get single entity, since SignInResult == SignUpResult
    /// </summary>
    public class SignInResult
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}