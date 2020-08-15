using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class CreateDirectChatPayload
    {
        [JsonProperty("username")] public string Username { get; set; }
    }
}