using System;

namespace ServicesLibrary.Exceptions.Auth
{
    /// <summary>
    /// Exception to be thrown at POST endpoint: auth/signUp
    /// </summary>
    public class TermsOfServiceNotAcceptedException : Exception
    {
        public TermsOfServiceNotAcceptedException(string message) : base(message)
        {
        }
    }
}