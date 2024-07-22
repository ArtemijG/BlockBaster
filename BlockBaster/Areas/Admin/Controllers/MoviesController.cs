using BlockBaster.Areas.Admin.Models;
using BlockBaster.Data;
using BlockBaster.Data.Entities;
using BlockBaster.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        public IActionResult ListScriptwriters()
        {
            IQueryable<Scriptwriter> scriptwriter = _db.Scriptwriters/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;
            ScriptwriterViewModel model = new ScriptwriterViewModel
            {
                scriptwriters = scriptwriter
            };
            return View(model);

        }


        [HttpGet]
        public IActionResult AddScriptwriters(int id)
        {
            var scriptwriter = id == default ? new Scriptwriter() : dataManager.Scriptwriter.GetScriptwriterById(id);


            return View(scriptwriter);

        }

        [HttpPost]
        public IActionResult AddScriptwriters(Scriptwriter scriptwriter, IFormFile imageFile, int id)
        {
            if (scriptwriter != null)
            {
                if (imageFile != null)
                {
                    scriptwriter.Path = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/Scriptwriters", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                }
                Scriptwriter p = new Scriptwriter
                {
                    Id = id,
                    Path = scriptwriter.Path,
                    Name = scriptwriter.Name,
                    Date = scriptwriter.Date
                };
                dataManager.Scriptwriter.SaveScriptwriter(p);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(scriptwriter);

        }

        [HttpGet]
        public IActionResult ListProducers()
        {
            IQueryable<Producer> producer = _db.Producers/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;
            ProducerViewModel model = new ProducerViewModel
            {
                producers = producer
            };
            return View(model);

        }


        [HttpGet]
        public IActionResult AddProducer(int id)
        {
            var producer = id == default ? new Producer() : dataManager.Producer.GetProducerById(id);


            return View(producer);

        }

        [HttpPost]
        public IActionResult AddProducer(Producer producer, IFormFile imageFile, int id)
        {
            if (producer != null)
            {
                if (imageFile != null)
                {
                    producer.Path = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/Producers", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                }
                Producer p = new Producer
                {
                    Id = id,
                    Path = producer.Path,
                    Name = producer.Name
                };
                dataManager.Producer.SaveProducer(p);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(producer);

        }

        [HttpGet]
        public IActionResult ListActors()
        {
            IQueryable<Actor> actors = _db.Actors/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;
            ActorViewModel model = new ActorViewModel
            {
                actors = actors
            };
            return View(model);

        }


        [HttpGet]
        public IActionResult AddActor(int id)
        {
            var actor = id == default ? new Actor() : dataManager.Actor.GetActorById(id);
            return View(actor);

        }

        [HttpPost]
        public IActionResult AddActor(Actor actor, IFormFile imageFile, int id)
        {
            if (actor != null)
            {
                if (imageFile != null)
                {
                    actor.Path = imageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/Actors", imageFile.FileName), FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                }
                Actor p = new Actor
                {
                    Id = id,
                    Path = actor.Path,
                    Name = actor.Name,
                    Date = actor.Date
                    
                };
                dataManager.Actor.SaveActor(p);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(actor);

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

        [HttpGet]
        public IActionResult SingleMovie(int id)
        {
            IQueryable<Movie> movie = _db.Movies.Where(s => s.Id == id);
            IQueryable<MovieGenre> movieGenres = _db.MovieGenres.Include(g => g.Movie).Include(d => d.Genre).Where(s => s.MovieId == id);
            IQueryable<ScriptwriterMovie> scriptwriterMovie = _db.ScriptwriterMovies.Include(g => g.Movie).Include(d => d.Scriptwriter).Where(s => s.MovieId == id);
            IQueryable<ProducerMovie> producerMovie = _db.ProducerMovies.Include(g => g.Movie).Include(d => d.Producer).Where(s => s.MovieId == id);
            IQueryable<ActorMovie> actorMovieT = _db.ActorMovies.Include(g => g.Movie).Include(d => d.Actor).Where(s => s.MovieId == id);
            var act = actorMovieT.ToList();
            IQueryable<MovieCountry> movieCountry = _db.MovieCountries.Include(g => g.Movie).Include(d => d.Country).Where(s => s.MovieId == id);

            //Movie m = new Movie();
            //m = movie.FirstOrDefault();

            var genre = movieGenres.FirstOrDefault().Genre.Name == default ? new Genre() : dataManager.Genre.GetGenreByName(movieGenres.FirstOrDefault().Genre.Name);
            var users = (from mGenres in _db.MovieGenres
                         where mGenres.MovieId == id
                         where mGenres.GenreId == genre.Id
                         select mGenres).ToList();


            var producer = movieGenres.FirstOrDefault().Genre.Name == default ? new Genre() : dataManager.Genre.GetGenreByName(movieGenres.FirstOrDefault().Genre.Name);
            //var m = movie.FirstOrDefault == default ? new Movie() : dataManager.Movie.GetMovieById(id);
            SingleMovieModel viewModel = new SingleMovieModel
            {
                movie = movie,
                movieGenres = users,
                scriptwriterMovies = scriptwriterMovie,
                producerMovies = producerMovie,
                actorMovies = actorMovieT,
                movieCountries = movieCountry,
                desc = movie.FirstOrDefault().Description,
                date = movie.FirstOrDefault().Date,
                path = movie.FirstOrDefault().Path,
                time = movie.FirstOrDefault().Time,
                name = movie.FirstOrDefault().Name,

                idGenre = genre.Id,
                genreName = genre.Name,// movieGenres.FirstOrDefault().Genre.Name,

                countryName = movieCountry.FirstOrDefault().Country.Name,
                
                //actor=actorMovie,
                //actorName = actorMovie.FirstOrDefault().Actor.Name,

                idProducer = producerMovie.FirstOrDefault().Producer.Id,
                producerName = producerMovie.FirstOrDefault().Producer.Name,
                idActor = actorMovieT.FirstOrDefault().Actor.Id,
                actorName = actorMovieT.FirstOrDefault().Actor.Name,
                scriptwriterName = scriptwriterMovie.FirstOrDefault().Scriptwriter.Name

               
        };

            //    foreach (var obj in actorMovieT)
            //        viewModel.actorNames;
            //for (int i = 0; act.Count() > i; i++)
            //    viewModel.actorNames[i] = act[i].Actor.Name;

            //IQueryable<ActorMovie> actorMovie = _db.ActorMovies.Include(g => g.Movie).Include(d => d.Actor).Where(s => s.MovieId == id);
            //viewModel.actors = _db.Actors.Include(g=> g.);




            //var movie = id == default ? new Movie() : dataManager.Movie.GetMovieById(id);


            return View(viewModel);

        }


        
        public IActionResult Edit(Actor actors, IFormFile imageFile,/*[FromBody]*/ SingleMovieModel singleMovieModel, int id, int idGenre, int idProducer, int idActor)
        {
            var movie = id == default ? new Movie() : dataManager.Movie.GetMovieById(id);
            singleMovieModel.id = movie.Id;
            movie.Description = singleMovieModel.desc;
            movie.Date = singleMovieModel.date;
            movie.Name = singleMovieModel.name;
            movie.Time = singleMovieModel.time;
            dataManager.Movie.SaveMovie(movie);

            //idGenre = singleMovieModel.movieGenres.FirstOrDefault().Genre.Id;
            var producer = idProducer == default ? new Producer() : dataManager.Producer.GetProducerById(idProducer);

            producer.Name = singleMovieModel.producerName;
            dataManager.Producer.SaveProducer(producer);

            var genre = idGenre == default ? new Genre() : dataManager.Genre.GetGenreById(idGenre);

            genre.Name = singleMovieModel.genreName;
            dataManager.Genre.SaveGenre(genre);

            var actor = idActor == default ? new Actor() : dataManager.Actor.GetActorById(idActor);
            //singleMovieModel.actorNames = actor;
            actor.Name = singleMovieModel.actorName;
            dataManager.Actor.SaveActor(actor);

            if (imageFile != null)
            {
                movie.Path = imageFile.FileName;
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/Movies", imageFile.FileName), FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

            }
            // IQueryable<ActorMovie> actorMovieT = _db.ActorMovies.Include(g => g.Movie).Include(d => d.Actor).Where(s => s.MovieId == id);
            //foreach (var obj in singleMovieModel.actorNames)
            //{
            //    var actor = obj == default ? new Actor() : dataManager.Actor.GetActorByName(obj);
            //    //singleMovieModel.actorNames = actor;
            //    actor.Name = obj;
            //    dataManager.Actor.SaveActor(actor);

            //}

            //genre.Name = singleMovieModel.Genre.Name;
            //var genre =movieGenres.FirstOrDefault().Genre.Name == default ? new Genre() : dataManager.Genre.GetGenreByName(movieGenres.FirstOrDefault().Genre.Name);
            //var genres = (from mGenres in _db.MovieGenres
            //              join g in _db.Genres on mGenres.GenreId equals g.Id
            //              join m in _db.Movies on mGenres.MovieId equals m.Id
            //              where mGenres.MovieId == id
            //              where mGenres.GenreId == singleMovieModel.Genre.Id
            //              select mGenres).ToList();


            //foreach (var obj in singleMovieModel.movieGenres)
            //{
            //    dataManager.Genre.SaveGenre(obj.Genre);
            //}

            //foreach (var mGenres in singleMovieModel.movieGenres)
            //{
            //    dataManager.MovieGenre.SaveMovieGenre(mGenres);
            //}


            //return RedirectToAction("Index", "Home");
            //return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ListGenres()
        {
            IQueryable<Genre> genres = _db.Genres/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;

            GenreViewModel viewModel = new GenreViewModel
            {
                genres = genres.ToList()

            };
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult AddGenre(int id)
        {
            var genres = id == default ? new Genre() : dataManager.Genre.GetGenreById(id);
            return View(genres);

        }

        [HttpPost]
        public IActionResult AddGenre(Genre genre)
        {
            if (genre.Name != null)
            {

                dataManager.Genre.SaveGenre(genre);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(genre);

        }

        [HttpGet]
        public IActionResult ListCountries()
        {
            IQueryable<Country> countries = _db.Countries/*.Include(g => g.Ganres).Include(dev => dev.Developers).Include(p => p.Platforms)*/;

            CountryViewModel viewModel = new CountryViewModel
            {
                countries = countries.ToList()

            };
            return View(viewModel);

        }

        [HttpGet]
        public IActionResult AddCountry(int id)
        {
            var countries = id == default ? new Country() : dataManager.Country.GetCountryById(id);
            return View(countries);

        }

        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            if (country.Name != null)
            {

                dataManager.Country.SaveCountry(country);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(country);

        }



    }
}

            


