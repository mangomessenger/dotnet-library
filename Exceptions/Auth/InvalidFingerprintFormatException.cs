using System;

namespace ServicesLibrary.Exceptions.Auth
{
    /// <summary>
    /// Exception to be thrown in POST endpoint: auth/sendCode
    /// </summary>
    public class InvalidFingerprintFormatException : Exception
    {
        public InvalidFingerprintFormatException(string message) : base(message)
        {
        }
    }
}