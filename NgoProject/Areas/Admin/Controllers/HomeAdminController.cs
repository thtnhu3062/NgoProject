using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Hosting;
using NgoProject.Models;
using NgoProject.ViewModel;
using System.Net;


namespace NgoProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/HomeAdmin")]
    public class HomeAdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly NgoProjectContext db;

        public HomeAdminController(NgoProjectContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;

        }

        [Route("")]
        [Route("Login")]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(string name, string pass)
        {
            if (ModelState.IsValid)
            {
                var acc = await db.Admins.SingleOrDefaultAsync(u => u.AdminName == name && u.AdminPassword == pass);

                if (acc != null)
                {
                    HttpContext.Session.SetString("name", name);
                    if (acc.AdminPassword == pass)
                    {
                        return RedirectToAction("Index", "HomeAdmin");
                    }
                }
                ViewBag.errors = "Invalid Name or PassWord";
            }
            return View();
        }
        [Route("index")]

        public IActionResult Index()
        {
            return View();
        }
        [Route("Category")]
        public IActionResult Category()
        {
            var lst = db.Categories.ToList();
            return View(lst);
        }
        [Route("AddCategory")]
        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }


        [Route("AddCategory")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory(Category sp)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Category");
            }
            return View(sp);

        }

        [Route("EditCategory")]
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var cate = db.Categories.Find(id);
            return View(cate);
        }
        [Route("EditCategory")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(Category cate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Category", "HomeAdmin");
            }
            return View(cate);

        }

        [Route("DeleteCategory")]
        [HttpGet]
        public async Task<ActionResult> DeleteCategory(int id)

        {
            TempData["Message"] = "";
            var cats =await db.News.Where(x=>x.NewsId==id).ToListAsync();
            if (cats.Count() > 0)
            {
                TempData["Message"] = "Can not delete";
                return RedirectToAction("Category", "HomeAdmin");

            }
            var cus = await db.Categories.SingleOrDefaultAsync(x => x.CategoryId == id);
            db.Categories.Remove(cus!);
            db.SaveChanges();
            TempData["Message"] = "Delete successfully";
            return RedirectToAction("Category", "HomeAdmin");
        }

        [Route("Banner")]
        [HttpGet]
        public IActionResult Banner()
        {
            return View(new Models.Ienumerable
            {

                Bn1 = db.Banners.ToList(),
                Bn2 = db.Bannersses.ToList()
            });

        }
     

        [Route("BannerEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BannerEdit(int id, ViewModelBanner model)
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

                Banner p = new Banner
                {
                    IdOne = model.Id,
                    TitleOne = model.Title,
                    ContentOne = model.Content,
                    ImageOne = imageFilename
                };


                // db.Set<Banner>().Update(p);

                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Banner", "HomeAdmin");
            }
            return View(model);
        }

        [Route("BannerEdit")]
        [HttpGet]
        public IActionResult BannerEdit(int id)
        {

            Banner? b = db.Banners!.Find(id);


            var Vi = new ViewModelBanner
            {
                Id = b.IdOne,
                Title = b.TitleOne,
                Content = b.ContentOne,


            };
            return View(Vi);
        }





        [Route("csxc09")]
        [HttpGet]
        public ActionResult BannerEdit2(int id)
        {
            //  Banner? b  =  await db.Banners!.SingleOrDefaultAsync(x => x.IdOne == id);
            Bannerss? k = db.Bannersses!.Find(id);

            var Vie = new ViewModelBanner
            {
                Id = k.IdTwo,
                Title = k.TitleTwo,
                Content = k.ContentTwo,

            };
            return View(Vie);
        }

        [Route("csxc09")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BannerEdit2(int id, ViewModelBanner model)
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
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.Image.CopyToAsync(fs);
                }

                Bannerss p = new Bannerss
                {
                    IdTwo = model.Id,
                    TitleTwo = model.Title,
                    ContentTwo = model.Content,
                    ImageTwo = imageFilename
                };


                // db.Set<Banner>().Update(p);
              
                db.Attach(p).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Banner", "HomeAdmin");
            }
            return View(model);
        }
        [Route("BannerAdd")]
        [HttpGet]
        public IActionResult BannerAdd()
        {
            return View();
        }
        [Route("BannerAdd")]
        [HttpPost]
        public async Task<IActionResult> BannerAdd(ViewModelBanner model)
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
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.Image.CopyToAsync(fs);
                }

                Bannerss p = new Bannerss
                {

                    TitleTwo = model.Title,
                    ContentTwo = model.Content,
                    ImageTwo = imageFilename




                };


                db.Bannersses!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Banner", "HomeAdmin");
            }
            return View(model);

        }
        [Route("DeleteBanner")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            TempData["Message"] = "";
            var cuse = await db.Bannersses.SingleOrDefaultAsync(x => x.IdTwo == id);
            db.Bannersses.Remove(cuse!);
            db.SaveChanges();
            TempData["Message"] = " Detele Succsessfully";
            return RedirectToAction("Banner", "HomeAdmin");
        }


        [Route("OurPartner")]
        [HttpGet]
        public async Task<IActionResult> OurPartner()
        {
            //return View(new Models.Ienumerable
            //{

            //    Ourpartner = db.Ourpartners.ToList(),
            //});
            return View(await db.Ourpartners.ToListAsync());


        }

        [Route("OurPartnerAdd")]
        [HttpGet]
        public IActionResult OurPartnerAdd()
        {
            return View();
        }
        [Route("OurPartnerAdd")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OurPartnerAdd(ViewModelOurPartner model)
        {

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.OurpartnerLogo != null && model.OurpartnerLogo.Length > 0)
                {
                    imageFilename = model.OurpartnerLogo.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.OurpartnerLogo.CopyToAsync(fs);
                }

                Ourpartner p = new Ourpartner
                {

                    OurpartnerName = model.OurpartnerName,
                    OurpartnerPhone = model.OurpartnerPhone,
                    OurpartnerAddressWeb = model.OurpartnerAddressWeb,
                    OurpartnerMail = model.OurpartnerMail,
                    OurpartnerAddress = model.OurpartnerAddress,
                    OurpartnerLogo = imageFilename



                };


                db.Ourpartners!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("OurPartner", "HomeAdmin");
            }
            return View(model);


        }
        public async Task<ActionResult> DeleteOur(int id)
        {
            TempData["Message"] = "";


            var cats = await db.News.Where(x => x.NewsId == id).ToListAsync();
            if (cats.Count() > 0)
            {
                TempData["Message"] = "Cannot be deleted when there are Causes";
                return RedirectToAction("OurPartner", "HomeAdmin");

            }
            var cuse = await db.Ourpartners.SingleOrDefaultAsync(x => x.OurpartnerId == id);
            db.Ourpartners.Remove(cuse!);
            db.SaveChanges();
            TempData["Message"] = "Succsessfully";
            return RedirectToAction("OurPartner", "HomeAdmin");
        }
        [Route("csxc094")]
        [HttpGet]
        public ActionResult OurPartnerEdit(int id)
        {
            Ourpartner? k = db.Ourpartners!.Find(id);

            return View(k);
        }

        [Route("csxc094")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OurPartnerEdit(int id ,  ViewModelOurPartner model)
        {
            Ourpartner? k = db.Ourpartners!.Find(id);

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.OurpartnerLogo != null && model.OurpartnerLogo.Length > 0)
                {
                    imageFilename = model.OurpartnerLogo.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "user/images/slide" );
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.OurpartnerLogo.CopyToAsync(fs);
                }

                Ourpartner p = new Ourpartner
                {
                    OurpartnerId = model.OurpartnerId,
                    OurpartnerName = model.OurpartnerName,
                    OurpartnerPhone = model.OurpartnerPhone,
                    OurpartnerAddressWeb = model.OurpartnerAddressWeb,
                    OurpartnerMail = model.OurpartnerMail,
                    OurpartnerAddress = model.OurpartnerAddress,
                    OurpartnerLogo = imageFilename

                };

                db.Entry(p).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("OurPartner", "HomeAdmin");
            }
            return View(model);
        }

        [Route("Donate")]
        [HttpGet]
        public async Task<IActionResult> Donate()
        {

            return View(await db.Donates.ToListAsync());

        }



        [Route("AboutUs")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View(new Models.Ienumerable
            {
                Abu = db.Aboutus.ToList(),
                questionAbouts = db.qa.ToList()
            });

        }



        [Route("AddQuestion")]
        [HttpGet]
        public IActionResult AddQuestion()
        {

            return View();
        }


        [Route("AddQuestion")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddQuestion(QuestionAbout qa)
        {
            if (ModelState.IsValid)
            {
                db.qa.Add(qa);
                db.SaveChanges();
                return RedirectToAction("AboutUs");
            }
            return View(qa);

        }

        [Route("EditQuestion")]
        [HttpPost]
        public async Task<IActionResult> EditQuestion(ViewModelQuestionAbout model)
        {

            if (ModelState.IsValid)
            {
                QuestionAbout ab = new QuestionAbout
                {
                    Id = model.Id,
                    Question = model.Question,
                    Answer = model.Answer,
                    //Image = imageFilename
                };

                db.Attach(ab).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AboutUs", "HomeAdmin");
            }
            return View(model);
        }

        [Route("EditQuestion")]
        [HttpGet]
        public async Task<IActionResult> EditQuestion(int id)
        {
            QuestionAbout? ab = await db.qa!.FindAsync(id);

            var view = new ViewModelQuestionAbout
            {
                Id = ab!.Id,
                Question = ab.Question,
                Answer = ab.Answer,
            };
            return View(view);
        }

        [Route("DeleteQuestion")]

        public async Task<ActionResult> DeleteQuestion(int id)
        {
            var cus = await db.qa!.SingleOrDefaultAsync(x => x.Id == id);
            db.qa.Remove(cus!);
            db.SaveChanges();
            return RedirectToAction("AboutUs", "HomeAdmin");
        }



        [Route("EditAbout")]
        [HttpPost]
        public async Task<IActionResult> EditAbout(ViewModelAbout model)
        {

            if (ModelState.IsValid)
            {
                string imageFilename = string.Empty;
                if (model.Photo != null && model.Photo.Length > 0)
                {
                    imageFilename = model.Photo.FileName;
                    var imgFolder = Path.Combine(_hostEnvironment.WebRootPath, "admin/uploads");
                    if (!Directory.Exists(imgFolder))
                    {
                        Directory.CreateDirectory(imgFolder);

                    }
                    var imgPath = Path.Combine(imgFolder, imageFilename);
                    var fs = new FileStream(imgPath, FileMode.OpenOrCreate);
                    await model.Photo.CopyToAsync(fs);
                }

                Aboutu ab = new Aboutu
                {
                    Id = model.Id,
                    Title = model.Title,
                    Content = model.Content,
                    Image = imageFilename
                };

                db.Attach(ab).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("AboutUs", "HomeAdmin");
            }
            return View(model);
        }

        [Route("EditAbout")]
        [HttpGet]
        public async Task<IActionResult> EditAbout(int id)
        {
            Aboutu? ab = await db.Aboutus!.FindAsync(id);

            var view = new ViewModelAbout
            {
                Id = ab!.Id,
                Title = ab.Title,
                Content = ab.Content,
            };
            return View(view);
        }

        [Route("DeleteAbout")]

        public async Task<ActionResult> DeleteAbout(int id)
        {
            var cus = await db.Aboutus!.SingleOrDefaultAsync(x => x.Id == id);
            db.Aboutus.Remove(cus!);
            db.SaveChanges();
            return RedirectToAction("AboutUs", "HomeAdmin");
        }

    }
}
