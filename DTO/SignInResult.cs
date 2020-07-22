using ServicesLibrary.Models;

namespace ServicesLibrary.DTO
{
    /// <summary>
    /// Response type of POST endpoint: auth/signIn
    /// NOTE: Consider to get single entity, since SignInResult == SignUpResult
    /// </summary>
    public class SignInResult
    {
        public User User { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}