using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Response type of POST endpoint: auth/signUp
    /// </summary>
    public class Session
    {
        [JsonProperty("user")] public User User { get; set; }
        [JsonProperty("tokens")] public Tokens Tokens { get; set; }
    }
}