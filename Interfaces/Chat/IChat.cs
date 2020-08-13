using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces.Chat
{
    public interface IChat
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("members")] public List<User> Members { get; set; }
        [JsonProperty("updated_at")] public int UpdatedAt { get; set; }
    }
}