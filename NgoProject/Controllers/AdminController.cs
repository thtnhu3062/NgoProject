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
        public async Task<IActionResult> Banner(int id)
        {
            BannerTable? b = await db.banners!.SingleOrDefaultAsync(x => x.Id == id); 

            return View(b);
        }
        [HttpPost]
        public async Task<IActionResult> Banner(int id , ViewModelBanner model)
        {
            if(ModelState.IsValid)
            {
                string imageFilename = string.Empty; 
                if(model.Image !=null && model.Image.Length > 0)
                {
                    imageFilename = model.Image.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if(!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.Create);
                    await model.Image.CopyToAsync(fs);
                }
                BannerTable p = new BannerTable
                {
                  Id = model.Id , 
                  Title = model.Title ,
                  Content = model.Content ,
                    Image = imageFilename
                };
                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index" , "User");
            }
            return View(model);
        }
       
    }
}

