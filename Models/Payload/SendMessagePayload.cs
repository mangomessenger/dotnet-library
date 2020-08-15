using System.Numerics;
using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class SendMessagePayload
    {
        [JsonProperty("chat_id")] public BigInteger ChatId { get; set; }
        [JsonProperty("chat_type")] public string ChatType { get; set; }
        [JsonProperty("message")] public string Message { get; set; }

        public SendMessagePayload(BigInteger chatId, string chatType, string message)
        {
            ChatId = chatId;
            ChatType = chatType;
            Message = message;
        }

        public SendMessagePayload()
        {
        }
    }
}