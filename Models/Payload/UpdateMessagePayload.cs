using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class UpdateMessagePayload
    {
        [JsonProperty("message")] public string Message { get; set; }
    }
}