using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    public interface IChatService
    {
        /// <summary>
        /// 
        /// Creates a new direct chat.
        ///
        /// See https://mangomessenger.com/methods/post/chats.direct-chats
        /// 
        /// </summary>
        public IChat CreateDirectChat(CreateDirectChatPayload payload);
    }
}