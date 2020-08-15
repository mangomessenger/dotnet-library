using System.Numerics;
using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Represents messages relation in database
    /// </summary>
    public class Message
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("chat_id")] public BigInteger ChatId { get; set; }
        [JsonProperty("from")] public User From { get; set; }
        [JsonProperty("message")] public string MessageText { get; set; }
        [JsonProperty("created_at")] public int CreatedAt { get; set; }
        [JsonProperty("updated_at")] public int UpdatedAt { get; set; }
    }
}