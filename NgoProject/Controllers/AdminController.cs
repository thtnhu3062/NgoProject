using Microsoft.AspNetCore.Mvc;
using NgoProject.Context;


using NgoProject.ViewModel;
using NgoProject.Models;
using Microsoft.EntityFrameworkCore;


namespace NgoProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly DatabaseContext db;

        public AdminController(DatabaseContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Banner1(int id)
        {


            BannerTable? b = await db.banner!.FindAsync(id);
            
            return View(b);
        }

    
        [HttpPost]
        public async Task<IActionResult> Banner1(int id, ViewModelBanner model)
        {
           

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.Image != null && model.Image.Length > 0)
                {
                    imageFilename = model.Image.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.Create);
                    await model.Image.CopyToAsync(fs);
                }
                BannerTable p = new BannerTable
                {
                    IdOne = model.Id,
                    TitleOne = model.Title,
                    ContentOne = model.Content,
                    ImageOne = imageFilename
                };
                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View(model);
         
        }


        [HttpGet]
        public async Task<IActionResult> Banner2(int id)
        {
            BannerTabless? b = await db.banners!.SingleOrDefaultAsync(x => x.IdTwo == id);
            return View(b);
        }

        [HttpPost]
        public async Task<IActionResult> Banner2(int id, ViewModelBanner model)
        {
          

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.Image != null && model.Image.Length > 0)
                {
                    imageFilename = model.Image.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.Create);
                    await model.Image.CopyToAsync(fs);
                }
                BannerTabless p = new BannerTabless
                {
                    IdTwo = model.Id,
                    TitleTwo = model.Title,
                    ContentTwo = model.Content,
                    ImageTwo = imageFilename
                };
                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Banner3(int id)
        {
         
            BannerTabless? b = await db.banners!.SingleOrDefaultAsync(x => x.IdTwo == id);
            return View(b);
        }

        [HttpPost]
        public async Task<IActionResult> Banner3(int id, ViewModelBanner model)
        {


            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.Image != null && model.Image.Length > 0)
                {
                    imageFilename = model.Image.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.Create);
                    await model.Image.CopyToAsync(fs);
                }
                BannerTabless p = new BannerTabless
                {
                    IdTwo = model.Id,
                    TitleTwo = model.Title,
                    ContentTwo = model.Content,
                    ImageTwo = imageFilename
                };
                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Admin");
            }
            return View(model);
        }

    }
}

