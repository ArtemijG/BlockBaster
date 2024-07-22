using BlockBaster.Areas.Admin.Models;
using BlockBaster.Areas.User.Models;
using BlockBaster.Data;
using BlockBaster.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlockBaster.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {

        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly AppDbContext _db;


        public HomeController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, AppDbContext db)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
            _db = db;

        }

        public IActionResult Index()
        {
            IQueryable<Movie> movie = _db.Movies;
            ViewMovieModel viewModel = new ViewMovieModel
            {
                movie = movie

            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ViewMovie(int id)
        {
            IQueryable<Movie> movie = _db.Movies.Where(s => s.Id == id);
            IQueryable<MovieGenre> movieGenres = _db.MovieGenres.Include(g => g.Movie).Include(d => d.Genre).Where(s => s.MovieId == id);
            IQueryable<ScriptwriterMovie> scriptwriterMovie = _db.ScriptwriterMovies.Include(g => g.Movie).Include(d => d.Scriptwriter).Where(s => s.MovieId == id);
            IQueryable<ProducerMovie> producerMovie = _db.ProducerMovies.Include(g => g.Movie).Include(d => d.Producer).Where(s => s.MovieId == id);
            IQueryable<ActorMovie> actorMovieT = _db.ActorMovies.Include(g => g.Movie).Include(d => d.Actor).Where(s => s.MovieId == id);
            var act = actorMovieT.ToList();
            IQueryable<MovieCountry> movieCountry = _db.MovieCountries.Include(g => g.Movie).Include(d => d.Country).Where(s => s.MovieId == id);

            Movie m = new Movie();
            m = movie.FirstOrDefault();

            var genre = movieGenres.FirstOrDefault().Genre.Name == default ? new Genre() : dataManager.Genre.GetGenreByName(movieGenres.FirstOrDefault().Genre.Name);
            var users = (from mGenres in _db.MovieGenres
                         where mGenres.MovieId == id
                         where mGenres.GenreId == genre.Id
                         select mGenres).ToList();


            var producer = movieGenres.FirstOrDefault().Genre.Name == default ? new Genre() : dataManager.Genre.GetGenreByName(movieGenres.FirstOrDefault().Genre.Name);

            ViewMovieModel viewModel = new ViewMovieModel
            {
                movie = movie,
                movieGenres = users,
                scriptwriterMovies = scriptwriterMovie,
                producerMovies = producerMovie,
                actorMovies = actorMovieT,
                movieCountries = movieCountry
                
            };
            return View(viewModel);
        }
    }

}
