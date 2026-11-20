using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CatController : Controller
    {
        // Статический список для сохранения данных между запросами в рамках сессии
        private static List<Cat> _cats = new List<Cat>
        {
            new Cat { Id = 1, Name = "Барсик", Breed = "Британская", Age = 3, Weight = 4.5, Color = "Серый", IsFavorite = true },
            new Cat { Id = 2, Name = "Мурка", Breed = "Сибирская", Age = 2, Weight = 3.8, Color = "Рыжий", IsFavorite = false },
            new Cat { Id = 3, Name = "Василий", Breed = "Мейн-кун", Age = 5, Weight = 7.2, Color = "Черный", IsFavorite = true }
        };

        // Главный список всех котиков
        public IActionResult Index()
        {
            return View(_cats);
        }

        // НОВЫЙ РАЗДЕЛ: Список любимых котиков
        public IActionResult Favorites()
        {
            var favoriteCats = _cats.Where(c => c.IsFavorite).ToList();
            return View(favoriteCats);
        }

        // Добавление котика (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Добавление котика (POST)
        [HttpPost]
        public IActionResult Create(Cat cat)
        {
            if (ModelState.IsValid)
            {
                cat.Id = _cats.Count > 0 ? _cats.Max(c => c.Id) + 1 : 1;
                _cats.Add(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // Метод для переключения статуса "Любимый"
        public IActionResult ToggleFavorite(int id)
        {
            var cat = _cats.FirstOrDefault(c => c.Id == id);
            if (cat != null)
            {
                cat.IsFavorite = !cat.IsFavorite; // Меняем на противоположное
            }
            return RedirectToAction("Index");
        }
    }
}
