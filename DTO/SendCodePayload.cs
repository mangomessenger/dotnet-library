namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type of POST endpoint: auth/sendCode
    /// </summary>
    public class SendCodePayload
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string Fingerprint { get; set; }
    }
}