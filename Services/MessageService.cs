﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public Message GetMessageById(int messageId)
        {
            var request = RestSharpRequest.Get(Route + messageId, _session);
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Message>(content);
        }

        public async Task<Message> GetMessageByIdAsync(int messageId)
        {
            var uri = new Uri(Route + messageId);
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message>(responseBody);
        }

        public List<Message> GetMessages(IChat chat)
        {
            var request = RestSharpRequest.Get(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(chat));
            var response = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<List<Message>>(response);
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

        public Message SendMessage(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var request = RestSharpRequest.Post(_session);
            request.AddJsonBody(JsonConvert.SerializeObject(messagePayload));
            var content = _restClient.Execute(request).Content;
            return JsonConvert.DeserializeObject<Message>(content);
        }

        public async Task<Message> SendMessageAsync(IChat chat, string text)
        {
            var messagePayload = new SendMessagePayload(chat.Id, chat.ChatType, text);
            var response = await HttpRequest.Post(_httpClient, Route, messagePayload);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Message>(responseBody);
        }

        public string UpdateMessage(Message message, string updatedText)
        {
            var request = RestSharpRequest.Put(Route + message.Id, _session);
            var payload = new UpdateMessagePayload {Message = updatedText};
            request.AddJsonBody(JsonConvert.SerializeObject(payload));
            var response = _restClient.Execute(request).Content;
            return response;
        }

        public async Task<string> UpdateMessageAsync(Message message, string updatedText)
        {
            var body = new UpdateMessagePayload {Message = updatedText};
            var response = await HttpRequest.Put(_httpClient, Route + message.Id, body);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<string>(responseBody);
        }

        public string DeleteMessage(Message message)
        {
            var request = RestSharpRequest.Delete(Route + message.Id, _session);
            var response = _restClient.Execute(request).Content;
            return response;
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