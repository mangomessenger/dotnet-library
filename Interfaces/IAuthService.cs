using System.Threading.Tasks;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    public interface IAuthService
    {
        Task<AuthRequest> SendCodeAsync(SendCodePayload payload);
        Task<Session> RegisterAsync(RegisterPayload payload);
        Task<Session> LoginAsync(LoginPayload payload);
        Task<string> LogoutAsync(Session session);
        Task<Tokens> RefreshTokensAsync(RefreshTokensPayload payload);
    }
}