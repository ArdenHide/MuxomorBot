using System.ComponentModel.DataAnnotations;

namespace MuxomorBot.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}