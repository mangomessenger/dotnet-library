using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using ServicesLibrary.ChatTypes;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class Group : IChat
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("creator")] public User Creator { get; set; }
        [JsonProperty("members")] public List<User> Members { get; set; }
        [JsonProperty("chat_type")] public string ChatType { get; set; } = TypesOfChat.Group;
        [JsonProperty("photo_url")] public string PhotoUrl { get; set; }
        [JsonProperty("members_count")] public int MembersCount { get; set; }
        [JsonProperty("updated_at")] public int UpdatedAt { get; set; }
    }
}