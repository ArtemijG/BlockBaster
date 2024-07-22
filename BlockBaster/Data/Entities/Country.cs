using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Country
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Страна выпуска")]
        public virtual string Name { get; set; }
    }
}
