using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public virtual string Name { get; set; }

        [Display(Name = "Дата выхода")]
        public virtual DateTime Date { get; set; }

        [Display(Name = "Путь")]
        public virtual string Path { get; set; }

        [Display(Name = "Длительность")]
        public virtual string Time { get; set; }

        [Display(Name = "Описание")]
        public virtual string Description { get; set; }
    }
}
