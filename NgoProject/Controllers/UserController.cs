using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
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
                News= db.News.Include(p => p.Category).Include(p => p.Ourpartner).ToList(),
                Ourpartner = db.Ourpartners.OrderByDescending(p=>p.OurpartnerId).ToList(),

            });


        }

        public ActionResult VoiGet()
        {
           return View();
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
        [HttpGet]
        public ActionResult ListNews()
        {

            return View(db.News.ToList());

        }
        [HttpGet]
        public ActionResult DetailsNews(int id)
        {
            News? k = db.News.Find(id);
            return View(k);
        }

        public ActionResult SearchNews(string searchString, int categoryID = 0)
        {
            var cat = from c in db.Categories select c;
            ViewBag.categoryID = new SelectList(cat, "CategoryId", "CategoryName");
            var links = from l in db.News
                        join c in db.Categories on l.CategoryId equals c.CategoryId
                        select new
                        {
                            l.NewsId,
                            l.NewsName,
                            l.NewsImage1,
                            l.NewsContent,
                            l.NewsDescription,
                            l.CategoryId,
                            c.CategoryName
                        };
            if (!String.IsNullOrEmpty(searchString))
            {
                links = links.Where(s => s.NewsName.Contains(searchString));
            }
            if (categoryID != 0)
            {
                links = links.Where(x => x.CategoryId == categoryID);
            }
            List<News> listNews = new List<News>();
            foreach (var item in links)
            {
                News news = new News();
                news.CategoryId = item.CategoryId;
                news.NewsContent = item.NewsContent;
                news.NewsDescription = item.NewsDescription;
                news.NewsId = item.NewsId;
                news.NewsName = item.NewsName;
                news.NewsImage1 = item.NewsImage1;
                listNews.Add(news);
            }
            return View(listNews);
        }

        public IActionResult IndexAboutUs()
        {

            return View(new Models.Ienumerable
            {
                Abu = db.Aboutus.ToList(),
                questionAbouts = db.qa.ToList(),
            });

        }

    }
}
