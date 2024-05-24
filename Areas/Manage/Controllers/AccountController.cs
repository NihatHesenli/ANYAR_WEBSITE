using ANYAR_WEBSITE.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

namespace ANYAR_WEBSITE.Areas.Manage.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVm registerVm)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
