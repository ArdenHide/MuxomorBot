using System.Collections.Generic;

namespace MuxomorBot.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }          
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
