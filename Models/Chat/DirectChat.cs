using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using ServicesLibrary.ChatTypes;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class DirectChat : IChat
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("members")] public List<User> Members { get; set; }
        [JsonProperty("chat_type")] public string ChatType => TypesOfChat.DirectChat;
        [JsonProperty("updated_at")] public int UpdatedAt { get; set; }
    }
}