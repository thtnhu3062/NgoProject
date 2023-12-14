using Microsoft.AspNetCore.Mvc;

namespace NgoProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
