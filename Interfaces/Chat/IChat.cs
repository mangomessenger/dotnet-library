﻿using System;
using System.Collections.Generic;
using ServicesLibrary.Enums;
using ServicesLibrary.Models;

namespace ServicesLibrary.Interfaces.Chat
{
    public interface IChat
    {
        public int Id { get; set; }
        public List<User> Members { get; set; }
        public ChatTypeEnum ChatType { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}