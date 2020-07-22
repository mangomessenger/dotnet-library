using Newtonsoft.Json;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Return type of POST endpoint: auth/refresh-token
    /// </summary>
    public class RefreshTokenResult : RefreshTokenPayload
    {
        [JsonProperty("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }
    }
}