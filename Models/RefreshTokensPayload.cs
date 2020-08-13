using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Payload type for POST endpoint: auth/refresh-token
    /// </summary>
    public class RefreshTokensPayload
    {
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }
        [JsonProperty("fingerprint")] public string Fingerprint { get; set; }

        public RefreshTokensPayload(string refreshToken, string fingerprint)
        {
            RefreshToken = refreshToken;
            Fingerprint = fingerprint;
        }

        public RefreshTokensPayload()
        {
        }
    }
}