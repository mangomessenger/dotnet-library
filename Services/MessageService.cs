using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;
using static ServicesLibrary.Routes.ApiRoutes;
using static ServicesLibrary.Routes.MessageRoutes;

namespace ServicesLibrary.Services
{
    public class MessageService : IMessageService
    {
        // "http://localhost/messages/"
        private static  readonly string Route = $"{ApiRoute}/{Messages}/";
        private readonly RestClient _restClient = new RestClient(Route);
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
        public Message GetMessageById(int messageId)
        {
            var request = new RestRequest(Route + messageId, Method.GET);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Message>(content);
        }

        /// <summary>
        /// 
        /// GET: Retrieves a list of past messages of a channel.
        /// 
        /// </summary>
        /// <returns>Enum of messages of chat by chat id</returns>
        public List<Message> GetMessages(IChat chat, out string response)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(chat));
            response = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<Message>>(response);
        }

        /// <summary>
        /// 
        /// POST: Sends a message to a chat.
        /// 
        /// </summary>
        public Message SendMessage(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
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
        public string UpdateMessage(Message message, string updatedText)
        {
            var request = new RestRequest(Route + message.Id, Method.PUT);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            var payload = new UpdateMessagePayload {Message = updatedText};
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var response = _restClient.Execute(request).Content;
            return response;
        }

        /// <summary>
        /// 
        /// DELETE: Deletes a message from a channel.
        /// 
        /// </summary>
        public string DeleteMessage(Message message)
        {
            var request = new RestRequest(Route + message.Id, Method.DELETE);
            request.AddHeader("Authorization", $"Bearer {_session.Tokens.AccessToken}");
            request.AddHeader("Content-type", "application/json");
            var response = _restClient.Execute(request).Content;
            return response;
        }
    }
}