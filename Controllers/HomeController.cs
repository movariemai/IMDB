﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using IMDB.Models;
using MvcMovie.Models;
using MvcMovie.Data;
using MvcActor.Models;
using MvcActor.Data;
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
        private readonly MvcActorContext _born;

        public HomeController(ILogger<HomeController> logger, MvcMovieContext released, MvcActorContext born)
        {
            _logger = logger;
            _released = released;
            _born = born;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BornThisMonth()
        {
            int currentMonth = DateTime.Now.Month;

            var actors = from a in _born.Actor.Where(a => (a.Birthday).Month == currentMonth) orderby (a.Birthday).Day
                    select a;

            return View(await actors.ToListAsync());
        }
		

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
