using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Payload type of POST endpoint: auth/signIn
    /// </summary>
    public class LoginPayload
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }
        [JsonProperty("phone_code")] public int PhoneCode { get; set; }
    }
}