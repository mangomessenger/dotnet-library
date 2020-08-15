using ServicesLibrary.Models;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.UserRoute;

namespace ServicesLibrary.Services
{
    public class UserService
    {
        // "http://localhost/users/"
        private static readonly string Route = $"{ApiRoot}/{Users}/";
        private readonly Session _session;

        public UserService(Session session)
        {
            _session = session;
        }
    }
}