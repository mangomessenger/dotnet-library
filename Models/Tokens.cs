using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    public class Tokens
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }
    }
}