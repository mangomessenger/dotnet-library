using System;
using System.Collections.Generic;
using System.Numerics;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class Channel : IChat
    {
        public BigInteger Id { get; set; }
        public List<User> Members { get; set; }
        public int UpdatedAt { get; set; }
    }
}