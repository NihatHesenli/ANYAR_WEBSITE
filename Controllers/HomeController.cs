using Microsoft.AspNetCore.Mvc;

namespace ANYAR_WEBSITE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
