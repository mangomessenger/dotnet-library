using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
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