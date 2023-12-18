using Microsoft.AspNetCore.Mvc;
using NgoProject.Context;
using NgoProjectLib;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO.Compression;
using NgoProject.ViewModel;

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
        public IActionResult Banner()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Bannershow()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Banner(ViewModelBanner vb)
        {
            if(ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if(vb.Photo !=null && vb.Photo.Length > 0)
                {
                    imageFilename = vb.Photo.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "imagess"); 
                    if(!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);
                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.Create);
                    await vb.Photo.CopyToAsync(fs);
                }
                Banner b = new Banner
                {
                    Photo = imageFilename
                };
                db.banners!.Add(b);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");


            }
            return View(vb);
        }

    }
}

