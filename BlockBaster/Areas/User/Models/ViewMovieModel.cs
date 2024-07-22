using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.User.Models
{
    public class ViewMovieModel
    {
        public IEnumerable<Movie> movie { get; set; }
        public IEnumerable<MovieGenre> movieGenres { get; set; }
        public IEnumerable<ScriptwriterMovie> scriptwriterMovies { get; set; }
        public IEnumerable<ProducerMovie> producerMovies { get; set; }
        public IEnumerable<ActorMovie> actorMovies { get; set; }
        public IEnumerable<MovieCountry> movieCountries { get; set; }
    }
}
