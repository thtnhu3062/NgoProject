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
            var list = await db.News.OrderByDescending(p=>p.NewsId).Include(p=>p.Category).Include(p => p.Ourpartner).ToListAsync();
            return View(list);


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
                    CategoryId = model.CategoryId,  
                    OurpartnerId = model.OurpartnerId,

                };


                db.News!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("News", "News");
            }
            return View(model);

        }
        [Route("NewsEdit")]
        [HttpGet]
        public ActionResult NewsEdit(int id)
        {
            ViewBag.CategoryId = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
            ViewBag.OurpartnerId = new SelectList(db.Ourpartners.ToList(), "OurpartnerId", "OurpartnerName");
            News? k = db.News!.Find(id);
            return View(k);
        }
        [Route("NewsEdit")]
        [HttpPost]
        public async Task<IActionResult> NewsEdit(int id, ViewModelNews model)
        {
            News? k = db.News!.Find(id);

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
                    CategoryId = model.CategoryId,
                    OurpartnerId = model.OurpartnerId,

                };


                db.Entry(p).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("News", "News");
            }
            return View(model);
        }
        [Route("DeleteNews")]

        public async Task<ActionResult> DeleteNews(int id)
        {
            var cus = await db.News!.SingleOrDefaultAsync(x => x.NewsId == id);

            db.News.Remove(cus!);
            db.SaveChanges();
            return RedirectToAction("News", "News");
        }
    }


}
