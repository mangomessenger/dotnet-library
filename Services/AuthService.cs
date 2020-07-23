﻿using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.DTO;
using ServicesLibrary.Exceptions.Auth;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;
using static ServicesLibrary.Auxiliaries.AuthServiceValidators;

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
        public AuthRequest SendCode(SendCodePayload code)
        {
            if (!PhoneIsValid(code.PhoneNumber))
                throw new InvalidPhoneNumberFormatException("Phone must be 9 digits long, w/o country code");

            if (!CountryCodeIsValid(code.CountryCode))
                throw new InvalidCountryCodeException("Country code cannot be null or empty");

            if (!FingerprintIsValid(code.Fingerprint))
                throw new InvalidFingerprintFormatException("Fingerprint length must be 10 or more digits");

            var request = new RestRequest(Url + "sendCode", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(code));
            var content = _restClient.Execute(request).Content;
            var deserializeContent = JsonConvert.DeserializeObject<AuthRequest>(content);
            return deserializeContent;
        }

        /// <summary>
        /// POST: Registration in messenger
        /// </summary>
        /// <param name="payload">SignUpPayload type</param>
        /// <returns>Session object</returns>
        public Session SignUp(SignUpPayload payload)
        {
            if (!TermsOfServicesAccepted(payload))
                throw new TermsOfServiceNotAcceptedException("Accept terms of services in order to sign up");

            var request = new RestRequest(Url + "signUp", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            var deserializeContent = JsonConvert.DeserializeObject<Session>(content);
            return deserializeContent;
        }

        /// <summary>
        /// POST: Login in messenger
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Session SignIn(SignInPayload payload)
        {
            var request = new RestRequest(Url + "signIn", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var content = _restClient.Execute(request).Content;
            var deserializeContent = JsonConvert.DeserializeObject<Session>(content);
            return deserializeContent;
        }

        /// <summary>
        /// POST: Logs out from messenger
        /// </summary>
        /// <param name="session">SignInResult type</param>
        /// <returns>True if ok, otherwise if was exception</returns>
        public bool Logout(Session session)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// POST: Refreshes tokens
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        public Token RefreshToken(TokenPayload payload)
        {
            throw new System.NotImplementedException();
        }
    }
}