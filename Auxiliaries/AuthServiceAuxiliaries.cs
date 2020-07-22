using System;
using System.Linq;
using AutoMapper;
using ServicesLibrary.DTO;
using ServicesLibrary.MapperProfiles;

namespace ServicesLibrary.Auxiliaries
{
    /// <summary>
    /// Auxiliary class in order to verify Auth Service parameters correct format
    /// </summary>
    public static class AuthServiceAuxiliaries
    {
        /// <summary>
        /// Verifies that phone number format is correct
        /// </summary>
        /// <param name="phone">String, param to be checked</param>
        /// <returns></returns>
        public static bool PhoneIsValid(string phone)
        {
            var data = phone.Replace('+', ' ').RemoveWhitespace();
            var correctLength = data.Length == 9;
            var digitsOnly = phone.All(char.IsDigit);
            return correctLength && digitsOnly;
        }

        /// <summary>
        /// Verifies that country code is valid
        /// </summary>
        /// <param name="code">String, param to be checked</param>
        /// <returns></returns>
        public static bool CountryCodeIsValid(string code)
        {
            return !string.IsNullOrEmpty(code);
        }

        /// <summary>
        /// Verifies that fingerprint has proper format
        /// </summary>
        /// <param name="print">String, fingerprint</param>
        /// <returns></returns>
        public static bool FingerprintIsValid(string print)
        {
            return print.Length > 9;
        }
        
        /// <summary>
        /// Checks whenever terms of services in SignUpPayload accepted
        /// </summary>
        /// <returns></returns>
        public static bool TermsOfServicesAccepted(SignUpPayload payload)
        {
            return payload.TermsOfServiceAccepted;
        }

        /// <summary>
        /// Generates mapper with required mapping profiles
        /// </summary>
        /// <returns></returns>
        public static Mapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new AuthProfiles());
                });
            
            return new Mapper(mapperConfig);
        }

        /// <summary>
        /// Extension method. Removes whitespaces from string.
        /// </summary>
        /// <param name="input">string, where need to remove w/s's</param>
        /// <returns></returns>
        private static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}