using BlockBaster.Data.Entities;
using BlockBaster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockBaster.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public AccountController(UserManager<User> userMgr, SignInManager<User> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null, model.Password),
                    SecurityStamp = string.Empty,
                    EmailConfirmed = true,
                    //WalletBalance = 0,
                    //CountryId= 1
                };

                IdentityUserRole<string> userRole = new IdentityUserRole<string>
                {
                    UserId = user.Id,
                    RoleId = "1"
                };
                // добавляем пользователя
                var resultUser = await userManager.CreateAsync(user);
                var resultRole = await userManager.AddToRoleAsync(user, "user");
                //IdentityRole resultRole = await    //userManager.AddToRoleAsync(user.Id,"user")
                if (resultUser.Succeeded && resultRole.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in resultUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            //return RedirectToAction("default");

        }
    }
}
