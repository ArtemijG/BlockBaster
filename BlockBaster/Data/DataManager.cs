using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockBaster.Data.Repositories.Abstract;

namespace BlockBaster.Data
{
    public class DataManager
    {
        public IActorMovieRepository ActorMovie { get; set; }
        public IActorRepository Actor { get; set; }
        public ICountryRepository Country { get; set; }
        public IGenreRepository Genre { get; set; }
        public IMovieCountryRepository MovieCountry { get; set; }
        public IMovieGenreRepository MovieGenre { get; set; }
        public IMovieRepository Movie { get; set; }
        public IProducerMovieRepository ProducerMovie { get; set; }
        public IProducerRepository Producer { get; set; }
       // public IRoleRepository Role { get; set; }
        public IScriptwriterMovieRepository ScriptwriterMovie { get; set; }
        public IScriptwriterRepository Scriptwriter { get; set; }
        public ISubscriptionRepository Subscription { get; set; }
        public IUserMovieRepository UserMovie { get; set; }
        public IUserRepository User { get; set; }
        //public IUserRoleRepository UserRole { get; set; }

        public DataManager(IActorMovieRepository ActorMovie, IActorRepository Actor, ICountryRepository Country, IGenreRepository Genre, IMovieCountryRepository MovieCountry,
            IMovieGenreRepository MovieGenre, IMovieRepository Movie, IProducerMovieRepository ProducerMovie, IProducerRepository Producer/*, IRoleRepository Role*/,
            IScriptwriterMovieRepository ScriptwriterMovie, IScriptwriterRepository Scriptwriter, ISubscriptionRepository Subscription, IUserMovieRepository UserMovie,
            IUserRepository User/*, IUserRoleRepository UserRole*/)
        {
            this.ActorMovie = ActorMovie;
            this.Actor = Actor;
            this.Country = Country;
            this.Genre = Genre;
            this.MovieCountry = MovieCountry;
            this.MovieGenre = MovieGenre;
            this.Movie = Movie;
            this.ProducerMovie = ProducerMovie;
            this.Producer = Producer;
            //this.Role = Role;
            this.ScriptwriterMovie = ScriptwriterMovie;
            this.Scriptwriter = Scriptwriter;
            this.Subscription = Subscription;
            this.UserMovie = UserMovie;
            this.User = User;
            //this.UserRole = UserRole;

        }
    }
}
