using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Interfaces
{
    public interface IChatService
    {
        public IChat CreateDirectChat(CreateDirectChatPayload payload);
    }
}