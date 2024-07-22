using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Models
{
    public class ListMovieModel
    {
        public IEnumerable<Movie> movies { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public IEnumerable<Scriptwriter> scriptwriters { get; set; }
        public IEnumerable<Producer> producers { get; set; }
        public IEnumerable<Actor> actors { get; set; }
        public IEnumerable<Country> countries { get; set; }
    }
}
