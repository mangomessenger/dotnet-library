using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using ServicesLibrary.Routes;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.AuthRoute;

namespace ServicesLibrary.Services
{
    public class AuthService : IAuthService
    {
        private static readonly string Route = $"{ApiRoot}/{Auth}/";
        private readonly RestClient _restClient = new RestClient(Route);
        private readonly HttpClient _httpClient = new HttpClient();

        public AuthRequest SendCode(SendCodePayload payload)
        {
            var request = RestSharpRequest.Post(Route + AuthRoute.SendCode);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<AuthRequest>(content);
        }

        public async Task<AuthRequest> SendCodeAsync(SendCodePayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + AuthRoute.SendCode, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthRequest>(responseBody);
        }

        public Session Register(RegisterPayload payload)
        {
            var request = RestSharpRequest.Post(Route + AuthRoute.Register);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Session>(content);
        }

        public async Task<Session> RegisterAsync(RegisterPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + AuthRoute.Register, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Session>(responseBody);
        }

        public Session Login(LoginPayload payload)
        {
            var request = RestSharpRequest.Post(Route + AuthRoute.Login);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Session>(content);
        }

        public async Task<Session> LoginAsync(LoginPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + AuthRoute.Login, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Session>(responseBody);
        }

        public string Logout(Session session)
        {
            var request = RestSharpRequest.Post(Route + AuthRoute.Logout);
            request.AddJsonBody(JsonConvert.SerializeObject(session.Tokens));
            var response = _restClient.Execute(request).Content;
            return response;
        }

        public async Task<string> LogoutAsync(Session session)
        {
            var response = await HttpRequest.Post(_httpClient, Route + AuthRoute.Logout, session.Tokens);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);
        }

        public Tokens RefreshTokens(RefreshTokensPayload payload)
        {
            var request = RestSharpRequest.Post(Route + AuthRoute.RefreshTokens);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Tokens>(content);
        }

        public async Task<Tokens> RefreshTokensAsync(RefreshTokensPayload payload)
        {
            var response = await HttpRequest.Post(_httpClient, Route + AuthRoute.RefreshTokens, payload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Tokens>(responseBody);
        }
    }
}