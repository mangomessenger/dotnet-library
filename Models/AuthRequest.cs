using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Response type of POST endpoint: auth/sendCode
    /// </summary>
    public class AuthRequest
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }
        [JsonProperty("is_new")] public bool IsNew { get; set; }
        [JsonProperty("timeout")] public int Timeout { get; set; }
    }
}