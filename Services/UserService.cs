using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServicesLibrary.Models;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.UserRoute;

namespace ServicesLibrary.Services
{
    public class UserService
    {
        // "http://localhost/users/"
        private static readonly string Route = $"{ApiRoot}/{Users}/";
        private readonly HttpClient _httpClient = new HttpClient();

        public UserService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<User> GetUserInfo(string username)
        {
            var response = await HttpRequest.Get(_httpClient, Route + username);
            return JsonConvert.DeserializeObject<User>(response);
        }
    }
}