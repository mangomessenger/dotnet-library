using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
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
        private const string Url = "http://mango-api.appdead.space/auth/";

        /// <summary>
        /// Instance of rest sharp to interact with database
        /// </summary>
        private readonly RestClient _restClient = new RestClient(Url);

        /// <summary>
        /// POST: Sends the verification code for SignIn / SignUp
        /// </summary>
        /// <param name="code">Payload type</param>
        /// <returns>Returns SendCodeResponse - required data for next step of authorization</returns>
        public SendCodeResult SendCode(SendCodePayload code)
        {
            if (code.PhoneNumber.Length != 9)
                throw new InvalidPhoneNumberFormatException("Phone must be 9 digits long");

            if (string.IsNullOrEmpty(code.CountryCode))
                throw new InvalidCountryCodeException("Country code cannot be null or empty");

            if (code.Fingerprint.Length < 10)
                throw new InvalidFingerprintFormatException("Fingerprint length must be 10 or more digits");

            var request = new RestRequest(Url + "sendCode", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(code));
            var content = _restClient.Execute(request).Content;
            var deserializeContent = JsonConvert.DeserializeObject<SendCodeResult>(content);
            return deserializeContent;
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