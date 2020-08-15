using System.Numerics;
using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class GetChatMessagesPayload
    {
        [JsonProperty("chat_id")] public BigInteger Id { get; set; }

        [JsonProperty("chat_type")] public string ChatType { get; set; }

        public GetChatMessagesPayload(BigInteger id, string chatType)
        {
            Id = id;
            ChatType = chatType;
        }

        public GetChatMessagesPayload()
        {
        }
    }
}