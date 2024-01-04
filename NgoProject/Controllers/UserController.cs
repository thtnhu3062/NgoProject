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
                Ourpartner = db.Ourpartners.OrderByDescending(p=>p.OurpartnerId).ToList(),

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

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ViewModelRegister model)
        {

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.UserAvatar != null && model.UserAvatar.Length > 0)
                {
                    imageFilename = model.UserAvatar.FileName;
                    var imgFolder = Path.Combine(env.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.UserAvatar.CopyToAsync(fs);
                }

                User p = new User
                {

                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    UserAddress = model.UserAddress,
                    UserPassword = model.UserPassword,
                    UserPhone = model.UserPhone,

                    UserAvatar = imageFilename



                };


                // db.Set<Banner>().Update(p);

                db.Set<User>().Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View(model);
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
