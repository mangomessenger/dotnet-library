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
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message>(responseBody);
        }

        public async Task<List<Message>> GetMessagesAsync(IChat chat)
        {
            var model = new GetChatMessagesPayload(chat.Id, chat.ChatType);
            var request = HttpRequest.Get(Route, model);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Message>>(responseBody);
        }

        public async Task<Message> SendMessageAsync(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var response = await HttpRequest.Post(_httpClient, Route, messagePayload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message>(responseBody);
        }

        public async Task<string> UpdateMessageAsync(Message message, string updatedText)
        {
            var body = new UpdateMessagePayload {Message = updatedText};
            var response = await HttpRequest.Put(_httpClient, Route + message.Id, body);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);
        }

        public async Task<string> DeleteMessageAsync(Message message)
        {
            var response = await HttpRequest.Delete(_httpClient, Route + message.Id);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);
        }
    }
}