using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Data.Entities
{
    public class UserRole:IdentityUserRole<int>
    {
        [Required]
        public int Id { get; set; }


        public override int UserId { get; set; }
        public User User { get; set; }

        public override int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
