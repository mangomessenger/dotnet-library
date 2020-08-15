using System.Threading.Tasks;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// 
    /// Public contract of authorization endpoints of the API: auth/sendCode, auth/signIn, auth/signUp
    /// 
    /// See https://mangomessenger.com/methods
    /// 
    /// </summary>
    public interface IAuthService
    {
        AuthRequest SendCode(SendCodePayload payload);
        Task<AuthRequest> SendCodeAsync(SendCodePayload payload);
        Session Register(RegisterPayload payload);
        Task<Session> RegisterAsync(RegisterPayload payload);
        Session Login(LoginPayload payload);
        Task<Session> LoginAsync(LoginPayload payload);
        string Logout(Session session);
        Task<string> LogoutAsync(Session session);
        Tokens RefreshTokens(RefreshTokensPayload payload);
        Task<Tokens> RefreshTokensAsync(RefreshTokensPayload payload);
    }
}