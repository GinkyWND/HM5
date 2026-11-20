using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Cat
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Кличка котика обязательна")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите породу")]
        public string Breed { get; set; }

        [Range(0, 30, ErrorMessage = "Возраст должен быть от 0 до 30")]
        public int Age { get; set; }

        [Range(0.1, 20.0, ErrorMessage = "Вес должен быть от 0.1 до 20 кг")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Выберите цвет")]
        public string Color { get; set; }

        // Новое свойство: любимый котик или нет
        public bool IsFavorite { get; set; }
    }
}
