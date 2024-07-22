using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Жанр")]
        public virtual string Name { get; set; }
    }
}
