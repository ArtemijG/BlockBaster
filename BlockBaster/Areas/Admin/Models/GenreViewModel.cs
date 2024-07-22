using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Models
{
    public class GenreViewModel
    {
        public IEnumerable<Genre> genres { get; set; }
        public string Name { get; set; }
    }
}
