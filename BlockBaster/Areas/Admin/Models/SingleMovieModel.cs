using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Models
{
    public class SingleMovieModel
    {
        public IEnumerable<Movie> movie { get; set; }
        public IEnumerable<MovieGenre> movieGenres { get; set; }
        public IEnumerable<ScriptwriterMovie> scriptwriterMovies { get; set; }
        public IEnumerable<ProducerMovie> producerMovies { get; set; }
        public IEnumerable<ActorMovie> actorMovies { get; set; }
        public IEnumerable<MovieCountry> movieCountries { get; set; }
        public Genre Genre { get; set; }

        //Movie
        public int id { get; set; }
        public string name { get; set; }
        public string desc { get; set; }
        public DateTime date { get; set; }
        public string path { get; set; }
        public string time { get; set; }

        
        public string genreName { get; set; }
        public int idGenre { get; set; }
        public string countryName { get; set; }
        public int idCountry { get; set; }
        public List<string> actorNames { get; set; } = new List<string>();
        public string actorName { get; set; }
        public int idActor { get; set; }
        public string producerName { get; set; }
        public int idProducer { get; set; }
        public string scriptwriterName { get; set; }
    }
}
