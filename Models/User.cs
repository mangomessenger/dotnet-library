using System;

namespace ServicesLibrary.Models
{
    /// <summary>
    /// Represents users relation in database
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}