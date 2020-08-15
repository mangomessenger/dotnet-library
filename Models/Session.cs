using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    public class Session
    {
        [JsonProperty("user")] public User User { get; set; }
        [JsonProperty("tokens")] public Tokens Tokens { get; set; }
    }
}