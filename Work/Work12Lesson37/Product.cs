using System;

namespace Work12Lesson37
{
    /// <summary>
    /// Класс описывающий товар
    /// </summary>
    class Product
    {
        Random _random = new Random();
        public Product()
        {
            Name = $"Товар от {DateTime.Now}";
            Id = _random.Next(1, 9999); 
        }
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
    }
}
