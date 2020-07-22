using ServicesLibrary.Models;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST method: auth/signUp
    /// </summary>
    public class SignUpResponse
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}