﻿using System.Collections.Generic;

namespace ServicesLibrary.Interfaces
{
    /// <summary>
    /// Interface for PUT, POST, GET etc interaction with messenger API
    /// </summary>
    /// <typeparam name="T">T - type of message, e.g: text, voice, smile, sticker</typeparam>
    public interface IMessageService<T> where T : class
    {
        /// <summary>
        /// GET: Returns message with specified id
        /// </summary>
        /// <param name="id">Integer, id of message to be returnes</param>
        /// <returns>T - message or null if no any</returns>
        T GetMessageById(int id);

        /// <summary>
        /// GET: Returns all messages from chat by id, chat is for two users only
        /// </summary>
        /// <param name="chatId">Integer, id of chat</param>
        /// <returns>Enum of messages of chat by chat id</returns>
        IEnumerable<T> GetChatMessagesById(int chatId);

        /// <summary>
        /// GET: Returns all messages from group by id
        /// </summary>
        /// <param name="groupId">Integer - id of group</param>
        /// <returns>Enum of messages of group by group id</returns>
        IEnumerable<T> GetGroupMessagesById(int groupId);

        /// <summary>
        /// POST: sends message to chat, group or readonly chat by id
        /// Data of chat_id, message type in inside parameter
        /// </summary>
        /// <param name="message">Message to be sent to chat</param>
        /// <returns>Instance of sent message</returns>
        T SendMessage(T message);

        /// <summary>
        /// PUT: Edits message as a whole, not partial edit
        /// </summary>
        /// <param name="message">T: message which to be edited</param>
        void EditMessage(T message);

        /// <summary>
        /// PATCH: partially edits message, eg. changes only its text, etc
        /// </summary>
        /// <param name="message"></param>
        void PartialEditMessage(T message);
        
        /// <summary>
        /// DELETE: deletes message from chat or group
        /// </summary>
        /// <param name="message">Message to be deleted</param>
        void DeleteMessage(T message);
    }
}