namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type for POST: auth/signUp
    /// </summary>
    public class SignUpPayload
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCodeHash { get; set; }
        public string Name { get; set; }
        public int PhoneCode { get; set; }
        public bool TermsOfServiceAccepted { get; set; }
    }
}