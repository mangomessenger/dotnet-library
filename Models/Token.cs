using Newtonsoft.Json;
using ServicesLibrary.DTO;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Return type of POST endpoint: auth/refresh-token
    /// </summary>
    public class Token : TokenPayload
    {
        [JsonProperty("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }
    }
}