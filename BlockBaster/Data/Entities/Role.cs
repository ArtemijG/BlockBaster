using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class Role:IdentityRole
    {
        //public override int Id { get; set; }
        public new int Id { get; set; }
    }
}
