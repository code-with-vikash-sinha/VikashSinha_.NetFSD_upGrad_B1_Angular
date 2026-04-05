using Microsoft.AspNetCore.Mvc;
using MMS.BAL.DTOs;
using MMS.BAL.Services;

namespace MMS.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("GetAllMovies")]

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        [Route("GetMovie/{MovieId}")]
        public IActionResult Details(int MovieId)
        {
            var movie = _movieService.GetMovieById(MovieId);
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                _movieService.Add(movieDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int MovieId)
        {
            var movie = _movieService.GetMovieById(MovieId);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieDto movieDto)
        {
            if (ModelState.IsValid)
            {
                _movieService.Update(movieDto);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
