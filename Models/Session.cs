using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Response type of POST endpoint: auth/signUp
    /// </summary>
    public class Session
    {
        [JsonProperty("user")]
        public User User { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}