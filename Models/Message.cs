using System;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Represents messages relation in database
    /// </summary>
    public class Message
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int UserId { get; set; }
        public string MessageText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}