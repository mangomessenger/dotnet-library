using System.Collections.Generic;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Models;

namespace ServicesLibrary.Implementations
{
    public class MessageService : IMessageService<Message>
    {
        /// <summary>
        /// Url of the api
        /// </summary>
        private const string Url = "http://mango-api.appdead.space/";
        
        /// <summary>
        /// Instance of rest sharp to interact with database
        /// </summary>
        private readonly RestClient _restClient = new RestClient();
        
        /// <summary>
        /// GET: Returns Message by id
        /// </summary>
        /// <param name="id">Integer, message id</param>
        /// <returns>Messages object</returns>
        public Message GetMessageById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// GET: Returns all messages from chat by chat id
        /// </summary>
        /// <param name="chatId">Integer, chat id</param>
        /// <returns>Enumerable messages</returns>
        public IEnumerable<Message> GetChatMessagesById(int chatId)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// GET: Returns all messages from group by group id
        /// </summary>
        /// <param name="groupId">Integer, group id</param>
        /// <returns>Enumerable messages</returns>
        public IEnumerable<Message> GetGroupMessagesById(int groupId)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// POST: Sends message to the chat
        /// NOTE: Consider use DTO as paramater
        /// </summary>
        /// <param name="message">Message instance</param>
        /// <returns>Message object</returns>
        public Message SendMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// PUT: Edit entire message (totally)
        /// </summary>
        /// <param name="message">Message to be edited</param>
        public void EditMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// PATCH: Partial edit message (text only)
        /// </summary>
        /// <param name="message">Message to be edited</param>
        public void PartialEditMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// DELETE: deletes message from chat or group
        /// </summary>
        /// <param name="message">Message to be deleted</param>
        public void DeleteMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}