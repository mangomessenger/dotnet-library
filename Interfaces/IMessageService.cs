using System.Collections.Generic;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// 
    /// Interface for PUT, POST, GET etc interaction with messenger API
    ///
    /// See also https://mangomessenger.com/methods
    /// </summary>
    /// <typeparam name="T">T - type of message, e.g: text, voice, smile, sticker</typeparam>
    public interface IMessageService<T> where T : class
    {
        /// <summary>
        /// GET: Returns message with specified id
        /// </summary>
        /// <param name="id">Integer, id of message to be returns</param>
        /// <returns>T - message or null if no any</returns>
        T GetMessageById(uint id);

        /// <summary>
        /// GET: Returns all messages from chat by id, chat is for two users only
        /// </summary>
        /// <param name="chat"></param>
        /// <returns>Enum of messages of chat by chat id</returns>
        IEnumerable<T> GetMessages(IChat chat);

        /// <summary>
        /// POST: sends message to chat, group or readonly chat by id
        /// Data of chat_id, message type in inside parameter
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="message">Message to be sent to chat</param>
        /// <returns>Instance of sent message</returns>
        T SendMessage(IChat chat, string message);

        /// <summary>
        /// PUT: Edits message as a whole, not partial edit
        /// </summary>
        /// <param name="message">T: message which to be edited</param>
        void UpdateMessage(T message);

        /// <summary>
        /// DELETE: deletes message from chat or group
        /// </summary>
        /// <param name="message">Message to be deleted</param>
        void DeleteMessage(T message);
    }
}