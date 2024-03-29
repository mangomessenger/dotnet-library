﻿using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class SendCodePayload
    {
        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("fingerprint")] public string Fingerprint { get; set; }

        public SendCodePayload(string phoneNumber, string countryCode, string fingerprint)
        {
            PhoneNumber = phoneNumber;
            CountryCode = countryCode;
            Fingerprint = fingerprint;
        }

        public SendCodePayload()
        {
        }
    }
}