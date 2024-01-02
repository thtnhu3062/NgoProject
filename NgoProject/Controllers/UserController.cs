using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using NgoProject.Models;
using NgoProject.ViewModel;
using QuickMailer;


namespace NgoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly NgoProjectContext db;
        private readonly IWebHostEnvironment env;

        public UserController(NgoProjectContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }


        [HttpGet]
        public IActionResult Index()
        {
            
            return View(new Models.Ienumerable
            {

                Bn1 = db.Banners.ToList(),
                Bn2 = db.Bannersses.ToList()
            });


        }

        public ActionResult VoiGet()
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






    }
}
