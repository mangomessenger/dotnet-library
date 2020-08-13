using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// 
    /// Public contract of authorization endpoints of the API: auth/sendCode, auth/signIn, auth/signUp
    /// 
    /// See https://mangomessenger.com/methods
    /// 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// 
        /// POST: Sends the verification code for SignIn / SignUp
        /// 
        /// See https://mangomessenger.com/methods/auth.sendCode
        /// 
        /// </summary>
        /// 
        /// <param name="code">Payload type</param>
        /// 
        /// <returns>Returns AuthRequest - required object for next step of authorization</returns>
        AuthRequest SendCode(SendCodePayload code);

        /// <summary>
        /// 
        /// POST: Registration in messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.signUp
        /// 
        /// </summary>
        /// 
        /// <param name="payload">Payload DTO</param>
        /// 
        /// <returns>Session object</returns>
        Session SignUp(RegisterPayload payload);
        
        /// <summary>
        /// 
        /// POST: Login in messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.signIn
        /// 
        /// </summary>
        /// 
        /// <param name="payload">Parameter: SingIn DTO object</param>
        /// 
        /// <returns>New session in messenger</returns>
        Session Login(LoginPayload payload);
        
        /// <summary>
        /// 
        /// POST: Logs out from messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.logout
        /// 
        /// </summary>
        /// 
        /// <param name="session">Parameter: Current session of user</param>
        /// 
        /// <returns>True if ok, otherwise if was exception</returns>
        bool Logout(Session session);
        
        /// <summary>
        /// 
        /// POST: Refreshes tokens
        /// 
        /// https://mangomessenger.com/methods/auth.refresh-tokens
        /// 
        /// </summary>
        /// 
        /// <param name="payload">TokenPayload DTO object</param>
        /// 
        /// <returns>Returns refreshed token object</returns>
        Tokens RefreshToken(RefreshTokensPayload payload);
    }
}