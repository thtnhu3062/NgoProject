using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
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
                Bn2 = db.Bannersses.ToList(),
                News= db.News.Include(p => p.Category).Include(p => p.Ourpartner).ToList(),
                Ourpartner = db.Ourpartners.OrderByDescending(p=>p.OurpartnerId).ToList(),

            });


        }

        public ActionResult VoiGet()
        {
           return View();
        }



            [HttpGet]
        public ActionResult OurPartner()
        {
            return View(db.Ourpartners.ToList()); 
        }
        [HttpGet]
        public ActionResult DetailsOur (int id)
        {
            Ourpartner? k = db.Ourpartners.Find(id);
            return View(k);
           
        }
        //public async Task<ActionResult> DetailsOur()
        //{

        //}

       
       

    }
}
