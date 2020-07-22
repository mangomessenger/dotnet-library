using ServicesLibrary.Models;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST endpoint: auth/signUp
    /// </summary>
    public class SignUpResult
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}