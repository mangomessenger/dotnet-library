using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
        private readonly HttpClient _httpClient = new HttpClient();

        public MessageService(Session session)
        {
            _httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", session.Tokens.AccessToken);
        }

        public async Task<Message> GetMessageByIdAsync(int messageId)
        {
            var response = await HttpRequest.Get(_httpClient, Route + messageId);
            return JsonConvert.DeserializeObject<Message>(response);
        }

        public async Task<List<Message>> GetMessagesAsync(IChat chat)
        {
            var model = new GetChatMessagesPayload(chat.Id, chat.ChatType);
            var response = await HttpRequest.Get(_httpClient, Route, model);
            return JsonConvert.DeserializeObject<List<Message>>(response);
        }

        public async Task<Message> SendMessageAsync(IChat chat, string text)
        {
            var body = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var response = await HttpRequest.Post(_httpClient, Route, body);
            return JsonConvert.DeserializeObject<Message>(response);
        }

        public async Task<string> UpdateMessageAsync(Message message, string updatedText)
        {
            var body = new UpdateMessagePayload {Message = updatedText};
            var response = await HttpRequest.Put(_httpClient, Route + message.Id, body);
            return JsonConvert.DeserializeObject<string>(response);
        }

        public async Task<string> DeleteMessageAsync(Message message)
        {
            var response = await HttpRequest.Delete(_httpClient, Route + message.Id);
            return JsonConvert.DeserializeObject<string>(response);
        }
    }
}