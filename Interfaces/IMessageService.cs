using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    public interface IMessageService
    {
        Task<Message> GetMessageByIdAsync(int messageId);
        Task<List<Message>> GetMessagesAsync(IChat chat);
        Task<Message> SendMessageAsync(IChat chat, string text);
        Task<string> UpdateMessageAsync(Message message, string updatedText);
        Task<string> DeleteMessageAsync(Message message);
    }
}