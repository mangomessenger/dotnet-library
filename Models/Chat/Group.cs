using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class Group : IChat
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("members")] public List<User> Members { get; set; }
        [JsonProperty("updated_at")] public int UpdatedAt { get; set; }
    }
}