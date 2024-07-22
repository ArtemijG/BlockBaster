using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlockBaster.Data.Entities
{
    public class User : IdentityUser
    {
        //public override int Id { get; set; }
        public int SubId { get; set; }
        public Subscription Subscription { get; set; }
    }
}
