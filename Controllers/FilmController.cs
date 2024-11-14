using Microsoft.AspNetCore.Mvc;
using CRUD.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD.Controllers
{
    public class FilmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){Id = 1, Name = "Film1", Description = "opis filmu1", Price=3},
            new Film(){Id = 2, Name = "Film2", Description = "opis filmu2", Price=5},
            new Film(){Id = 3, Name = "Film3", Description = "opis filmu3", Price=3},
        };

        // GET: Film
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: Film/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
            films.Add(film);
            return RedirectToAction(nameof(Index));
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Film/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Film updatedFilm)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                film.Name = updatedFilm.Name;
                film.Description = updatedFilm.Description;
                film.Price = updatedFilm.Price;
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Film/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            var film = films.FirstOrDefault(x => x.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }
    }
} 