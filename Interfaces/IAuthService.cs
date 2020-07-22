using ServicesLibrary.DTO;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// Public contract of authorization endpoints: auth/sendCode, auth/signIn, auth/signUp
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// POST: Sends the verification code for SignIn / SignUp
        /// </summary>
        /// <param name="code">Payload type</param>
        /// <returns>Returns SendCodeResponse - required data for next step of authorization</returns>
        SendCodeResult SendCode(SendCodePayload code);

        /// <summary>
        /// POST: Registration in messenger
        /// </summary>
        /// <param name="payload">Payload DTO</param>
        /// <returns>Session object</returns>
        SignUpResult SignUp(SignUpPayload payload);
        
        /// <summary>
        /// POST: Login in messenger
        /// </summary>
        /// <param name="payload"></param>
        /// <returns>New session in messenger</returns>
        SignInResult SignIn(SignInPayload payload);
        
        /// <summary>
        /// POST: Logs out from messenger
        /// </summary>
        /// <param name="session">SignInResult type</param>
        /// <returns>True if ok, otherwise if was exception</returns>
        bool Logout(SignInResult session);
        
        /// <summary>
        /// POST: Refreshes tokens
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        RefreshTokenResult RefreshToken(RefreshTokenPayload payload);
    }
}