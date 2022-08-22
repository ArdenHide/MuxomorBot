namespace MuxomorBot.Data.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }            // Отображаемое имя продукции
        public string Type { get; set; }            // Тип продукции
        public int Weight { get; set; }             // Вес
        public double Price { get; set; }           // Цена
        public string Photo { get; set; }           // Путь к фото
        public bool IsAvailability { get; set; }    // Есть в наличии
        public int Discount { get; set; }           // Скидка
        public string Description { get; set; }     // Описание

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
