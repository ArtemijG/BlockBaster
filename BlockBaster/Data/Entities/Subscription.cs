using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Subscription
    {
        [Required]
        public int Id { get; set; }


        [Display(Name = "Дата начала")]
        public virtual DateTime DateBegin { get; set; }

        [Display(Name = "Дата конца")]
        public virtual DateTime DateEnd { get; set; }
    }
}
