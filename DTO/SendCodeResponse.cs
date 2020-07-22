namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST endpoint: auth/sendCode
    /// </summary>
    public class SendCodeResponse
    {
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCodeHash { get; set; }
        public bool IsNew { get; set; }
        public int Timeout { get; set; }
    }
}