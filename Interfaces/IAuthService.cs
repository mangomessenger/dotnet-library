using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;

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
        /// <param name="payload">Payload type</param>
        /// 
        /// <returns>Returns AuthRequest - required object for next step of authorization</returns>
        AuthRequest SendCode(SendCodePayload payload);

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
        Session Register(RegisterPayload payload);
        
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
        string Logout(Session session);
        
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