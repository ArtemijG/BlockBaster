using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class ProducerMovie
    {
        [Required]
        public int Id { get; set; }

        public int ProducerId { get; set; }
        public Producer Producer { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
