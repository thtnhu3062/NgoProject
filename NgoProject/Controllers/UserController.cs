using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NgoProject.Context;


namespace NgoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IWebHostEnvironment env;

        public UserController(DatabaseContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var content = await db.banners?.ToListAsync();
            return View(content);
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
