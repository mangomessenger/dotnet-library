using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using ServicesLibrary.Interfaces;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.Models;
using ServicesLibrary.Models.Payload;
using ServicesLibrary.Requests;
using static ServicesLibrary.Routes.ApiRoute;
using static ServicesLibrary.Routes.MessageRoute;

namespace ServicesLibrary.Services
{
    public class MessageService : IMessageService
    {
        // "http://localhost/messages/"
        private static readonly string Route = $"{ApiRoot}/{Messages}/";
        private readonly RestClient _restClient = new RestClient(Route);
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly Session _session;

        public MessageService(Session session)
        {
            _session = session;
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", _session.Tokens.AccessToken);
        }


        /// <summary>
        /// 
        /// GET: Retrieves information on a message.
        /// 
        /// </summary>
        public Message GetMessageById(int messageId)
        {
            var request = ApiRequest.Get(Route + messageId, _session);
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
            var request = ApiRequest.Get(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(chat));
            response = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<Message>>(response);
        }

        public async Task<List<Message>> GetMessagesAsync(IChat chat)
        {
            var model = new GetChatMessagesPayload(chat.Id, chat.ChatType);
            var payload = JsonConvert.SerializeObject(model);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(Route),
                Content = new StringContent(payload, Encoding.Default, "application/json")
            };
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            
            return JsonConvert.DeserializeObject<List<Message>>(responseBody);
        }

        /// <summary>
        /// 
        /// POST: Sends a message to a chat.
        /// 
        /// </summary>
        public Message SendMessage(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var request = ApiRequest.Post(_session);
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
            var request = ApiRequest.Put(Route + message.Id, _session);
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
            var request = ApiRequest.Delete(Route + message.Id, _session);
            var response = _restClient.Execute(request).Content;
            return response;
        }
    }
}