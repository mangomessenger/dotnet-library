using Newtonsoft.Json;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type of POST endpoint: auth/signIn
    /// </summary>
    public class SignInPayload
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("phone_code_hash")]
        public string PhoneCodeHash { get; set; }
        [JsonProperty("phone_code")]
        public int PhoneCode { get; set; }
    }
}