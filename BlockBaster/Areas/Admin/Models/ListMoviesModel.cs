using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Models
{
    public class ListMoviesModel
    {
        public IEnumerable<Movie> movies { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public IEnumerable<Scriptwriter> scriptwriters { get; set; }
        public IEnumerable<Producer> producers { get; set; }
        public IEnumerable<Actor> actors { get; set; }
        public IEnumerable<Country> countries { get; set; }
    }
}
