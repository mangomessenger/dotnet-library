using System.Collections.Generic;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// 
    /// Interface to interaction with messenger API
    ///
    /// See also https://mangomessenger.com/methods
    /// 
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// 
        /// GET: Retrieves information on a message.
        /// 
        /// </summary>
        Message GetMessageById(int id);

        /// <summary>
        /// 
        /// GET: Retrieves a list of past messages of a channel.
        /// 
        /// </summary>
        List<Message> GetMessages(IChat chat, out string response);

        /// <summary>
        /// 
        /// POST: Sends a message to a chat.
        /// 
        /// </summary>
        Message SendMessage(IChat chat, string text);

        /// <summary>
        /// 
        /// PUT: Updates information on a message in a chat. Return server's response
        /// 
        /// </summary>
        string UpdateMessage(Message message, string updatedText);

        /// <summary>
        /// 
        /// DELETE: Deletes a message from a channel. Return server's response.
        /// 
        /// </summary>
        string DeleteMessage(Message message);
    }
}