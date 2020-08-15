using System.Numerics;
using Newtonsoft.Json;

namespace ServicesLibrary.Models
{
    public class User
    {
        [JsonProperty("id")] public BigInteger Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("bio")] public string Bio { get; set; }
        [JsonProperty("photo_url")] public string PhotoUrl { get; set; }
        [JsonProperty("verified")] public bool Verified { get; set; }
    }
}