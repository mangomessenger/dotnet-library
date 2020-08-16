using System.Collections.Generic;
using Newtonsoft.Json;
using ServicesLibrary.Models.Chat;

namespace ServicesLibrary.Models
{
    public class UserChats
    {
        [JsonProperty("direct-chats")] public List<DirectChat> DirectChats { get; set; }
        [JsonProperty("channels")] public List<Channel> Channels { get; set; }
        [JsonProperty("groups")] public List<Group> Groups { get; set; }
    }
}