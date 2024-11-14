using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class FilmController : Controller
    {

        private static IList<Film> films = new List<Film>
        {
            new Film() { Id = 1, Name = "The Godfather", Description = "By: Francis Ford Coppola", Price = 192 },
            new Film() { Id = 2, Name = "The Shawshank Redemption", Description = "By: Frank Darabont", Price = 14 },
            new Film() { Id = 3, Name = "The Dark Knight", Description = "By: Christopher Nolan", Price = 200 }

        };

        // GET: FilController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FilController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(f => f.Id == id));
        }

        // GET: FilController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {

            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));   
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film film)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            film.Name = film.Name;
            film.Description = film.Description;
            film.Price = film.Price;

            return RedirectToAction(nameof(Index));
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Film movie)
        {
            Film film = films.FirstOrDefault(x => x.Id == id);
            films.Remove(film);
            return RedirectToAction(nameof(Index));

        }
    }
}
