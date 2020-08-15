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
        AuthRequest SendCode(SendCodePayload payload);

        /// <summary>
        /// 
        /// POST: Registration in messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.signUp
        /// 
        /// </summary>
        Session Register(RegisterPayload payload);
        
        /// <summary>
        /// 
        /// POST: Login in messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.signIn
        /// 
        /// </summary>
        Session Login(LoginPayload payload);
        
        /// <summary>
        /// 
        /// POST: Logs out from messenger
        /// 
        /// See https://mangomessenger.com/methods/auth.logout
        /// 
        /// </summary>
        string Logout(Session session);
        
        /// <summary>
        /// 
        /// POST: Refreshes tokens
        /// 
        /// https://mangomessenger.com/methods/auth.refresh-tokens
        /// 
        /// </summary>
        Tokens RefreshTokens(RefreshTokensPayload payload);
    }
}