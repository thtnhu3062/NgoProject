using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgoProject.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;


namespace NgoProject.Controllers
{
    public class DonateController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly NgoProjectContext db;

        public DonateController(NgoProjectContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;

        }

        [Route("Donate")]
        public IActionResult Donate()
        {
            var lst = db.Donates.ToList();
            return View(lst);
        }
        [Route("AddDonate")]
        [HttpGet]
        public IActionResult AddDonate()
        {

            return View();
        }


        [Route("AddDonate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDonate(Donate sp)
        {
            if (ModelState.IsValid)
            {
                db.Donates.Add(sp);
                db.SaveChanges();
                return RedirectToAction("/");
            }
            return View(sp);

        }
    }
    }
