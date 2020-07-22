using Newtonsoft.Json;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type for POST endpoint: auth/refresh-token
    /// </summary>
    public class RefreshTokenPayload
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}