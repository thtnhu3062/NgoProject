using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NgoProject.Models;
using NgoProject.ViewModel;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace NgoProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/News")]
    public class NewsController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly NgoProjectContext db;

        public NewsController(NgoProjectContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }



        [Route("News")]
        [HttpGet]
        public async Task<IActionResult> News()
        {   
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.OurpartnerId = new SelectList(db.Ourpartners.ToList(), "OurpartnerId", "OurpartnerName");

            return View(await db.News.OrderByDescending(p=>p.NewsId).Include(p=>p.Category).Include(p=>p.Ourpartner).ToListAsync());


        }

        [Route("NewsAdd")]
        [HttpGet]
        public IActionResult NewsAdd()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.OurpartnerId = new SelectList(db.Ourpartners.ToList(), "OurpartnerId", "OurpartnerName");
            return View();
        }
        [Route("NewsAdd")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewsAdd(ViewModelNews model)
        {


            if (ModelState.IsValid)
            {
                string imageFilename1 = string.Empty;
                if (model.NewsImage1 != null && model.NewsImage1.Length > 0)
                {
                    imageFilename1 = model.NewsImage1.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename1);
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.NewsImage1.CopyToAsync(fs);
                }

                News p = new News
                {

                    NewsName = model.NewsName,
                    NewsContent = model.NewsContent,
                    NewsDescription = model.NewsDescription,
                    NewsImage1 = imageFilename1,

                };


                db.News!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("News", "News");
            }
            return View(model);

        }
    }


}
