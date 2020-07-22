using Newtonsoft.Json;
using ServicesLibrary.Models;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST endpoint: auth/signUp
    /// </summary>
    public class SignUpResult
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}