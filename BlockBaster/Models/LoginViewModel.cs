using BlockBaster.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Models
{
    public class LoginViewModel
    {
        //LOGIN
        [Required(ErrorMessage = "Не указан Логин")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Не указан Пароль")]
        [UIHint("password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        //LISTMOVIE
        public IEnumerable<Movie> movies { get; set; }

        //SIGNUP
        //[Required(ErrorMessage = "Не указан Логин при регистрации")]
        public string UserName_SignUp { get; set; }

        //[Required(ErrorMessage = "Не указан Пароль при регистрации")]
        [UIHint("password")]
        public string Password_SignUp { get; set; }

        [Compare("Password_SignUp", ErrorMessage = "Пароли не совпадают")]
        [UIHint("password")]
        public string Password_SignUp2 { get; set; }
        public string Email { get; set; }

    }
}
