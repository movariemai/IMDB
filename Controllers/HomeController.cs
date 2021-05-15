using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using IMDB.Models;
using MvcMovie.Models;
using MvcMovie.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcMovieContext _released;

        public HomeController(ILogger<HomeController> logger, MvcMovieContext released)
        {
            _logger = logger;
            _released = released;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TopMovies()
        {
            var movies = from m in _released.Movies.Where(m => m.Rating >= 8) orderby m.Rating descending
                         select m;
            
            return View(await movies.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
