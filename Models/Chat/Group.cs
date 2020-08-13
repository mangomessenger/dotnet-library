using System.Collections.Generic;
using System.Numerics;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class Group : IChat
    {
        public BigInteger Id { get; set; }
        public List<User> Members { get; set; }
        public int UpdatedAt { get; set; }
    }
}