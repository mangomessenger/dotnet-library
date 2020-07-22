using System;

namespace ServicesLibrary.Exceptions.Auth
{
    /// <summary>
    /// Exception of POST endpoint: auth/sendCode.
    /// To be thrown if phone number length not equal to 9
    /// </summary>
    public class InvalidPhoneNumberFormatException : Exception
    {
        public InvalidPhoneNumberFormatException(string message) : base(message)
        {
        }
    }
}