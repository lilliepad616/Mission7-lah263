using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission7_lah263.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//Lillie Heath
//Mission 7

namespace Mission06_lah263.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieApplicationContext _movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieApplicationContext ma)
        {
            _logger = logger;
            _movieContext = ma;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View(new NewMovie());
        }
        [HttpPost]
        public IActionResult NewMovie(NewMovie nm)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(nm);
                _movieContext.SaveChanges();
                return View("Confirmation", nm);

            }
            else
            {
                return View(nm);
            }
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewMovies()
        {
            var applications = _movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit (int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var application = _movieContext.Responses.Single(x => x.MovieID == id);

            return View("NewMovie", application);
        }
        [HttpPost]

        public IActionResult Edit (NewMovie nm)
        {
            _movieContext.Update(nm);
            _movieContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete (int id)
        {
            var application = _movieContext.Responses.Single(x => x.MovieID == id);
            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(NewMovie nm)
        {
            _movieContext.Responses.Remove(nm);
            _movieContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }
    }
}

