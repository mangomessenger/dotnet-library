﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServicesLibrary.Models.Payload
{
    public class CreateCommunityPayload
    {
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("usernames")] public List<string> Usernames { get; set; }
    }
}