using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;

namespace ServicesLibrary.Services
{
    public class MessageService : IMessageService
    {
        private readonly RestClient _restClient = new RestClient();
        private const string Url = "http://localhost/messages";
        private readonly Session _session;

        public MessageService(Session session)
        {
            _session = session;
        }


        /// <summary>
        /// 
        /// GET: Retrieves information on a message.
        /// 
        /// </summary>
        public Message GetMessageById(BigInteger id)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// GET: Retrieves a list of past messages of a channel.
        /// 
        /// </summary>
        /// <returns>Enum of messages of chat by chat id</returns>
        public List<Message> GetMessages(IChat chat)
        {
            var request = new RestRequest(Url, Method.GET);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}\"");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(chat));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<Message>>(content);
        }

        /// <summary>
        /// 
        /// POST: Sends a message to a chat.
        /// 
        /// </summary>
        public Message SendMessage(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var request = new RestRequest(Url, Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}\"");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(messagePayload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Message>(content);
        }

        /// <summary>
        /// 
        /// PUT: Updates information on a message in a chat.
        /// 
        /// </summary>
        public void UpdateMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// DELETE: Deletes a message from a channel.
        /// 
        /// </summary>
        public void DeleteMessage(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}