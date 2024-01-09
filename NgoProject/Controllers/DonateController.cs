using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NgoProject.Models;
using NgoProject.ViewModel;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;


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
        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            var list = await db.Donates.OrderByDescending(p => p.NewsId).Include(p => p.User).Include(p => p.News).ToListAsync();
            return View(list);


        }
        [Route("DonateAdd")]
        [HttpGet]
        public IActionResult DonateAdd()
        {
            ViewBag.UserId = new SelectList(db.Users.ToList(), "UserId", "UserName");
            ViewBag.NewsId = new SelectList(db.News.ToList(), "NewsId", "NewsName");
            return View();
        }
        [Route("DonateAdd")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DonateAdd(DonateViewModel model)
        {


            if (ModelState.IsValid)
            {


                Donate p = new Donate()
                {

                    DonateMoney = model.DonateMoney,
                    DonateDate = model.DonateDate,
                    UserId = model.UserId,
                    NewsId = model.NewsId,

                };


                db.Donates!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Payment");
            }
            return View(model);

        }

        [Route("Payment")]
        [HttpGet]
        public IActionResult Payment()
        {
         
            return View();


        }

    }
    }
