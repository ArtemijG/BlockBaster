using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Models
{
    public class CountryViewModel
    {
        public IEnumerable<Country> countries { get; set; }
        public string Name { get; set; }
    }
}
