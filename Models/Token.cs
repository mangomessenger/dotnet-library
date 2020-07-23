using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Return type of POST endpoint: auth/refresh-token
    /// </summary>
    public class Token
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

        [JsonProperty("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }
    }
}