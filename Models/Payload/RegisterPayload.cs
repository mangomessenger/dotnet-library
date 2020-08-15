using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    /// <summary>
    /// Payload type of POST endpoint: auth/register
    /// </summary>
    public class RegisterPayload
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("phone_code_hash")] public string PhoneCodeHash { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("phone_code")] public int PhoneCode { get; set; }

        [JsonProperty("terms_of_service_accepted")]
        public bool TermsOfServiceAccepted { get; set; }
    }
}