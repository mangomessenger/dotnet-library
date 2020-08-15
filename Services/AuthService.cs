using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using ServicesLibrary.Routes;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.AuthRoute;
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
        private static readonly string Route = $"{ApiRoute.ApiRoot}/{Auth}/";
        private readonly RestClient _restClient = new RestClient(Route);


        /// <summary>
        /// 
        /// POST: Sends the verification code for register / login
        /// 
        /// See https://mangomessenger.com/methods/auth.sendCode
        /// 
        /// </summary>
        public AuthRequest SendCode(SendCodePayload payload)
        {
            if (!PhoneIsValid(payload.PhoneNumber))
                throw new InvalidPhoneNumberFormatException("Phone must be 9 digits long, w/o country code");

            if (!CountryCodeIsValid(payload.CountryCode))
                throw new InvalidCountryCodeException("Country code cannot be null or empty");

            if (!FingerprintIsValid(payload.Fingerprint))
                throw new InvalidFingerprintFormatException("Fingerprint length must be 5 or more digits");

            var request = ApiRequest.Post(Route + AuthRoute.SendCode);
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
        public Session Register(RegisterPayload payload)
        {
            if (!TermsOfServicesAccepted(payload))
                throw new TermsOfServiceNotAcceptedException("Accept terms of services in order to sign up");

            var request = ApiRequest.Post(Route + AuthRoute.Register);
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
        public Session Login(LoginPayload payload)
        {
            var request = ApiRequest.Post(Route + AuthRoute.Login);
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
        public string Logout(Session session)
        {
            var request = ApiRequest.Post(Route + AuthRoute.Logout);
            request.AddJsonBody(JsonConvert.SerializeObject(session.Tokens));
            var response = _restClient.Execute(request).Content;
            return response;
        }

        /// <summary>
        /// 
        /// POST: Refreshes tokens
        /// 
        /// https://mangomessenger.com/methods/post/auth.refresh-tokens
        /// 
        /// </summary>
        public Tokens RefreshTokens(RefreshTokensPayload payload)
        {
            var request = ApiRequest.Post(Route + AuthRoute.RefreshTokens);
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Tokens>(content);
        }
    }
}