using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BlockBaster.Data.Entities;

namespace BlockBaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserManager<BlockBaster.Data.Entities.User> userManager;
        private readonly SignInManager<Data.Entities.User> signInManager;
        public HomeController (UserManager <Data.Entities.User> userMgr, SignInManager<Data.Entities.User> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddMovie()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("default");
        }
    }
}
