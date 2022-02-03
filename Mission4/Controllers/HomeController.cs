using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext { get; set; }

        public HomeController(MovieContext someName)
        {
            _movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            
            return View();
        }
        [HttpPost]
        public IActionResult Movie(MovieResponse movie) 
        {
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("MovieConfirmation", movie);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View();
            }
        }
        public IActionResult MovieList()
        {
            var movies = _movieContext.Responses
                .Include(x => x.Category)
                .ToList();

            
            return View(movies);
        }
        [HttpGet]
        public IActionResult Edit(int categoryid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Responses.Single(x => x.CategoryID == categoryid);
            
            return View("Movie", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieResponse m)
        {
            _movieContext.Update(m);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Delete()
        //{
        //    return View();
        //}
    }
}
