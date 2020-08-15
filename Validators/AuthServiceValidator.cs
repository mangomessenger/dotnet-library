﻿using System.Linq;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Validators
{
    /// <summary>
    /// Auxiliary class in order to verify Auth Service parameters correct format
    /// </summary>
    public static class AuthServiceValidator
    {
        /// <summary>
        /// Verifies that phone number format is correct
        /// </summary>
        /// <param name="phone">String, param to be checked</param>
        /// <returns></returns>
        public static bool PhoneIsValid(string phone)
        {
            return phone.Length >= 9;
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
            return print.Length > 5;
        }

        /// <summary>
        /// Checks whenever terms of services in SignUpPayload accepted
        /// </summary>
        /// <returns></returns>
        public static bool TermsOfServicesAccepted(RegisterPayload payload)
        {
            return payload.TermsOfServiceAccepted;
        }

        /// <summary>
        /// Extension method. Removes whitespaces from string.
        /// </summary>
        /// <param name="input">string, where need to remove w/s's</param>
        /// <returns></returns>
        private static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}