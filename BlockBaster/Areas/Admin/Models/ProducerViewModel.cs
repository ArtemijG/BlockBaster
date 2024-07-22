using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Areas.Admin.Models
{
    public class ProducerViewModel
    {
        public IEnumerable<Producer> producers { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
    }
}
