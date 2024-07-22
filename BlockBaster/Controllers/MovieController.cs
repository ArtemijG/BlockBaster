using BlockBaster.Areas.Admin.Models;
using BlockBaster.Data;
using BlockBaster.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Models
{
    public class MoviesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;

        public MoviesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;
        }

        [HttpGet]
        public IActionResult ListMovie()
        {
            IQueryable<Movie> movies = _db.Movies/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;

            ListMoviesModel viewModel = new ListMoviesModel
            {
                movies = movies.ToList()

            };
            return View(viewModel);
            

        }

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{

        //    var allGames = id == default ? new AllGames() : dataManager.AllGames.GetAllGamesByid(id);
        //    var developers = dataManager.Developers.GetDevelopersByid(allGames.Developersid);
        //    var platforms = dataManager.Platforms.GetPlatformsByid(allGames.Platformsid);
        //    var ganres = dataManager.Ganres.GetGanresByid(allGames.Ganresid);

        //    SelectList GanreDropList = new SelectList(_db.Ganres, "nameGanres", "nameGanres");
        //    ViewBag.GanresList = GanreDropList;

        //    SelectList DevelopersDropList = new SelectList(_db.Developers, "nameDeveloper", "nameDeveloper");
        //    ViewBag.DevelopersList = DevelopersDropList;

        //    SelectList PlatformsDropList = new SelectList(_db.Platforms, "namePlatform", "namePlatform");
        //    ViewBag.PlatformsList = PlatformsDropList;

        //    return View(allGames);
        //}
    }
}

