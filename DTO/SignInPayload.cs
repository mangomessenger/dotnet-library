namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Payload type of POST endpoint: auth/signIn
    /// </summary>
    public class SignInPayload
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCodeHash { get; set; }
        public int PhoneCode { get; set; }
    }
}