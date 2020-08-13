using System;
using System.Collections.Generic;
using ServicesLibrary.Enums;
using ServicesLibrary.Interfaces.Chat;

namespace ServicesLibrary.Models.Chat
{
    public class DirectChat : IChat
    {
        public int Id { get; set; }
        public List<User> Members { get; set; }
        public ChatTypeEnum ChatType { get; set; } = ChatTypeEnum.DirectChat;
        public DateTime UpdatedAt { get; set; }
    }
}