using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Scriptwriter
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        public virtual string Name { get; set; }

        [Display(Name = "Дата рождения")]
        public virtual DateTime Date { get; set; }

        [Display(Name = "Фото")]
        public virtual string Path { get; set; }
    }
}
