using Newtonsoft.Json;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type for POST endpoint: auth/refresh-token
    /// </summary>
    public class TokenPayload
    {
        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }
        [JsonProperty("fingerprint")] public string Fingerprint { get; set; }

        public TokenPayload(string refreshToken, string fingerprint)
        {
            RefreshToken = refreshToken;
            Fingerprint = fingerprint;
        }

        public TokenPayload()
        {
        }
    }
}