using System;

namespace MuxomorBot.Data.Entities
{
    public class Application : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Phone { get; set; }
        public Product Products { get; set; }
        public string SelectedPayment { get; set; }
    }
}
