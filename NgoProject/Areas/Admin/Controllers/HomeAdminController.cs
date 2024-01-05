using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        //  NgoProjectContext db=new NgoProjectContext();
        [Route("")]
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


        [Route("Users")]
        [HttpGet]
        public async Task<IActionResult> Users()
        {

            return View(await db.Users.ToListAsync());

        }

        [Route("Donate")]
        [HttpGet]
        public IActionResult Donate()
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


                // db.Set<Banner>().Update(p);

                db.Ourpartners!.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("OurPartner", "HomeAdmin");
            }
            return View(model);

        }
        [Route("DeleteOur")]

        public async Task<ActionResult> DeleteOur(int id)
        {
            var cus = await db.Ourpartners!.SingleOrDefaultAsync(x => x.OurpartnerId == id);

            db.Ourpartners.Remove(cus!);
            db.SaveChanges();
            return RedirectToAction("OurPartner", "HomeAdmin");
        }

        [Route("csxc094")]
        [HttpGet]
        public ActionResult OurPartnerEdit(int id)
        {
            //  Banner? b  =  await db.Banners!.SingleOrDefaultAsync(x => x.IdOne == id);
            Ourpartner? k = db.Ourpartners!.Find(id);

            //var Vie = new ViewModelBanner
            //{
            //    Id = k.IdTwo,
            //    Title = k.TitleTwo,
            //    Content = k.ContentTwo,

            //};
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


               //  db.Set<Ourpartner>().Update(p); nay la add 
                db.Entry(p).State = EntityState.Modified;
              //  db.Attach(p).State = EntityState.Modified;

                await db.SaveChangesAsync();
                return RedirectToAction("OurPartner", "HomeAdmin");
            }
            return View(model);
        }


    }
}
