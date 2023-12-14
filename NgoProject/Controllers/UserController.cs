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
    }
}
