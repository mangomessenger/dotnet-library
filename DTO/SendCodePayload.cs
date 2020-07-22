using Newtonsoft.Json;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type of POST endpoint: auth/sendCode
    /// </summary>
    public class SendCodePayload
    {
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }
    }
}