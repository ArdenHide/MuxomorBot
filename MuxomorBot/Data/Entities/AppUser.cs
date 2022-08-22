using System;

namespace MuxomorBot.Data.Entities
{
    public class AppUser : BaseEntity
    {
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}