using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Return type of POST endpoint: auth/refresh-token
    /// </summary>
    public class Tokens
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }
    }
}