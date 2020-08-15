using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class LoginPayload
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }
        [JsonProperty("phone_code")] public int PhoneCode { get; set; }
    }
}