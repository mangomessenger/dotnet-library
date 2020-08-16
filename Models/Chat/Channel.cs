using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using ServicesLibrary.Interfaces.Chat;
using ServicesLibrary.ChatTypes;

namespace ServicesLibrary.Models.Chat
{
    public class Channel : IChat
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("creator")] public User Creator { get; set; }
        [JsonProperty("members")] public List<User> Members { get; set; }
        [JsonProperty("chat_type")] public string ChatType { get; set; } = TypesOfChat.Channel;
        [JsonProperty("tag")] public string Tag { get; set; }
        [JsonProperty("photo_url")] public string PhotoUrl { get; set; }
        [JsonProperty("verified")] public bool Verified { get; set; }
        [JsonProperty("members_count")] public int MembersCount { get; set; }
        [JsonProperty("updated_at")] public long UpdatedAt { get; set; }
    }
}