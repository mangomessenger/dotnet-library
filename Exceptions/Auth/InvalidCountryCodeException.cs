using System;

namespace ServicesLibrary.Exceptions.Auth
{
    /// <summary>
    /// Exception to be thrown in POST endpoint: auth/sendCode
    /// </summary>
    public class InvalidCountryCodeException : Exception
    {
        public InvalidCountryCodeException(string message) : base(message)
        {
        }
    }
}