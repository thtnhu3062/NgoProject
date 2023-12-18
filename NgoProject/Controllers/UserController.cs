using Microsoft.AspNetCore.Mvc;

namespace NgoProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Donate()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Banner()
        {
            return View();
        }
    }
}
