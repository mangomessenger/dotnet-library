namespace ServicesLibrary.Models
{
    /// <summary>
    /// Represents auth_requests relation in database
    /// </summary>
    public class AuthRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string PhoneCodeHash { get; set; }
    }
}