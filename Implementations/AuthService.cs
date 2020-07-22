using RestSharp;
using ServicesLibrary.DTO;
using ServicesLibrary.Interfaces;

namespace ServicesLibrary.Implementations
{
    /// <summary>
    /// Concrete implementation of authorization endpoints: auth/sendCode, auth/signIn, auth/signUp
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// Url of the api
        /// </summary>
        private const string Url = "http://mango-api.appdead.space/";

        /// <summary>
        /// Instance of rest sharp to interact with database
        /// </summary>
        private readonly RestClient _restClient = new RestClient();

        /// <summary>
        /// POST: Sends the verification code for SignIn / SignUp
        /// </summary>
        /// <param name="code">Payload type</param>
        /// <returns>Returns SendCodeResponse - required data for next step of authorization</returns>
        public SendCodeResult SendCode(SendCodePayload code)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// POST: Registration in messenger
        /// </summary>
        /// <param name="payload">Payload DTO</param>
        /// <returns>Session object</returns>
        public SignUpResult SignUp(SignUpPayload payload)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// POST: Login in messenger
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public SignInResult SignIn(SignInPayload payload)
        {
            throw new System.NotImplementedException();
        }
    }
}