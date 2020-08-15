using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.AuthRoute;

namespace ServicesLibrary.Services
{
    public class AuthService : IAuthService
    {
        private static readonly string Route = $"{ApiRoot}/{Auth}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<AuthRequest> SendCodeAsync(SendCodePayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + SendCode, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthRequest>(responseBody);
        }

        public async Task<Session> RegisterAsync(RegisterPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + Register, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Session>(responseBody);
        }

        public async Task<Session> LoginAsync(LoginPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + Login, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Session>(responseBody);
        }

        public async Task<string> LogoutAsync(Session session)
        {
            var response = await HttpRequest.Post(_httpClient, Route + Logout, session.Tokens);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);
        }

        public async Task<Tokens> RefreshTokensAsync(RefreshTokensPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + RefreshTokens, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tokens>(responseBody);
        }
    }
}