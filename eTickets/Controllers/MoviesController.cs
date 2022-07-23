using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(n => n.Platform);
            return View(allMovies);
        }

        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Platforms = new SelectList(movieDropdownData.Platforms, "Id", "PlatformName");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "ProducerFullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "ActorFullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Platforms = new SelectList(movieDropdownData.Platforms, "Id", "PlatformName");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "ProducerFullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "ActorFullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null) return View("NotFound");

            var response = new NewMovieVM
            {
                Id = movieDetails.Id,
                MovieTitle = movieDetails.MovieTitle,
                MovieDescription = movieDetails.MovieDescription,
                MoviePrice = movieDetails.MoviePrice,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieImageURL = movieDetails.MovieImageURL,
                MovieCategory = movieDetails.MovieCategory,
                PlatformId = movieDetails.PlatformId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };


            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Platforms = new SelectList(movieDropdownData.Platforms, "Id", "PlatformName");
            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "ProducerFullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "ActorFullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Platforms = new SelectList(movieDropdownData.Platforms, "Id", "PlatformName");
                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "ProducerFullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "ActorFullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Platform);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(x => x.MovieTitle.ToLower().Contains(searchString.ToLower()) || x.MovieDescription.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }
    }
}
