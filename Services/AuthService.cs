using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using static ServicesLibrary.Validators.AuthServiceValidator;

namespace ServicesLibrary.Services
{
    /// <summary>
    /// 
    /// Concrete implementation of authorization endpoints of API: send-code, register, login, logout, refresh-tokens
    /// 
    /// See https://mangomessenger.com/methods
    /// 
    /// </summary>
    public class AuthService : IAuthService
    {
        /// <summary>
        /// URL of the API
        /// </summary>
        private const string Url = "http://10.160.3.105/auth/";

        /// <summary>
        /// Instance of RestSharp client to interact with API
        /// </summary>
        private readonly RestClient _restClient = new RestClient(Url);

        /// <summary>
        /// 
        /// POST: Sends the verification code for register / login
        /// 
        /// See https://mangomessenger.com/methods/auth.sendCode
        /// 
        /// </summary>
        /// 
        /// <param name="payload">Payload type</param>
        /// 
        /// <returns>Returns AuthRequest - required object for next step of authorization</returns>
        public AuthRequest SendCode(SendCodePayload payload)
        {
            if (!PhoneIsValid(payload.PhoneNumber))
                throw new InvalidPhoneNumberFormatException("Phone must be 9 digits long, w/o country code");

            if (!CountryCodeIsValid(payload.CountryCode))
                throw new InvalidCountryCodeException("Country code cannot be null or empty");

            if (!FingerprintIsValid(payload.Fingerprint))
                throw new InvalidFingerprintFormatException("Fingerprint length must be 5 or more digits");

            var request = new RestRequest(Url + "send-code", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<AuthRequest>(content);
        }

        /// <summary>
        /// 
        /// POST: Registration in messenger
        /// 
        /// See https://mangomessenger.com/methods/post/auth.register
        /// 
        /// </summary>
        /// 
        /// <param name="payload">Payload DTO</param>
        /// 
        /// <returns>Session object</returns>
        public Session Register(RegisterPayload payload)
        {
            if (!TermsOfServicesAccepted(payload))
                throw new TermsOfServiceNotAcceptedException("Accept terms of services in order to sign up");

            var request = new RestRequest(Url + "register", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Session>(content);
        }

        /// <summary>
        /// 
        /// POST: Login in messenger
        /// 
        /// See https://mangomessenger.com/methods/post/auth.login
        /// 
        /// </summary>
        /// 
        /// <param name="payload">Parameter: Login DTO object</param>
        /// 
        /// <returns>New session in messenger</returns>
        public Session Login(LoginPayload payload)
        {
            var request = new RestRequest(Url + "login", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Session>(content);
        }

        /// <summary>
        /// 
        /// POST: Logs out from messenger
        /// 
        /// See https://mangomessenger.com/methods/post/auth.logout
        /// 
        /// </summary>
        /// 
        /// <param name="session">Parameter: Current session of user</param>
        /// 
        /// <returns>True if ok, otherwise if was exception</returns>
        public bool Logout(Session session)
        {
            var request = new RestRequest(Url + "logout", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(session.Tokens));
            var content = _restClient.Execute(request).Content;
            return !content.Contains("400") && !content.Contains("422");
        }

        /// <summary>
        /// 
        /// POST: Refreshes tokens
        /// 
        /// https://mangomessenger.com/methods/post/auth.refresh-tokens
        /// 
        /// </summary>
        /// 
        /// <param name="payload">TokenPayload DTO object</param>
        /// 
        /// <returns>Returns refreshed token object</returns>
        public Tokens RefreshToken(RefreshTokensPayload payload)
        {
            var request = new RestRequest(Url + "refresh-tokens", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Tokens>(content);
        }
    }
}