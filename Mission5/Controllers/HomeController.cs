using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext moneyContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieApplicationContext someName)
        {
            moneyContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovies()
        {
            ViewBag.Categories = moneyContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult NewMovies(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {
                moneyContext.Add(mr);
                moneyContext.SaveChanges();

                return View("Confirmation", mr);
            }
            else // if invalid
            {
                ViewBag.Categories = moneyContext.Categories.ToList();

                return View();
            }

        }

        public IActionResult MovieList()
        {
            var movies = moneyContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Director)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = moneyContext.Categories.ToList();

            var movie = moneyContext.Responses.Single(x => x.MovieId == movieid);

            return View("NewMovies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieResponse money)
        {
            moneyContext.Update(money);
            moneyContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = moneyContext.Responses.Single(x => x.MovieId == movieid);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            moneyContext.Responses.Remove(mr);
            moneyContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
