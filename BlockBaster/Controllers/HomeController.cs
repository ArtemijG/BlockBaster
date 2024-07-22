using BlockBaster.Models;
using BlockBaster.Data;
using BlockBaster.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using BlockBaster.Service;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BlockBaster.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UserManager<User> userManager;
        //private readonly SignInManager<User> signInManager;

        //public HomeController(UserManager<User> userMgr, SignInManager<User> signinMgr)
        //{
        //    userManager = userMgr;
        //    signInManager = signinMgr;
        //}


        private readonly AppDbContext _db;
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager, AppDbContext db)
        {
            this.dataManager = dataManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Search(string name/*, int? ganre, int? platfoms, int? developres, int price_from, int price_before*/)
        {
            IQueryable<Movie> movies = _db.Movies;

            if (!String.IsNullOrEmpty(name))
            {
                movies = movies.Where(a => a.Name.Contains(name));
            }


            ListMovieModel viewModel = new ListMovieModel
            {
                movies = movies.ToList()

            };
            return View(viewModel);
            //return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            //return Redirect(returnUrl ?? "/");
            //return RedirectToAction("Admin","Home", "Index");
            //return Redirect("~/Account/Login");
            //return RedirectToRoute("Account", new { controller = "Account", action = "Login" });
        }
        [HttpGet]
        public IActionResult ListMovie()
        {
            IQueryable<Movie> movies = _db.Movies/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;

            LoginViewModel viewModel = new LoginViewModel
            {
                movies = movies.ToList()

            };
            return View(viewModel);


        }
    }
}
