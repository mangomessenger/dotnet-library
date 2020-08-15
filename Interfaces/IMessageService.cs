using System.Collections.Generic;
using System.Threading.Tasks;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    public interface IMessageService
    {
        Message GetMessageById(int messageId);
        Task<Message> GetMessageByIdAsync(int messageId);
        List<Message> GetMessages(IChat chat);
        Task<List<Message>> GetMessagesAsync(IChat chat);
        Message SendMessage(IChat chat, string text);
        Task<Message> SendMessageAsync(IChat chat, string text);
        string UpdateMessage(Message message, string updatedText);
        Task<string> UpdateMessageAsync(Message message, string updatedText);
        string DeleteMessage(Message message);
        Task<string> DeleteMessageAsync(Message message);
    }
}