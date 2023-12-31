using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgoProject.Models;


namespace NgoProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/HomeAdmin")]
    public class HomeAdminController : Controller
    {
        NgoProjectContext db=new NgoProjectContext();
        [Route("")]
        [Route("index")]

        public IActionResult Index()
        {
            return View();
        }
        [Route("Category")]
        public IActionResult Category()
        {

            var lst=db.Categories.ToList();
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
        public IActionResult Users()
        {

            return View();
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

        [Route("News")]
        public IActionResult News()
        {

            return View();
        }
        [Route("AddNews")]
        [HttpGet]
        public IActionResult AddNews()
        {

            return View();
        }

        //[Route("AddCategory")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult AddCategory(Category sp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Categories.Add(sp);
        //        db.SaveChanges();
        //        return RedirectToAction("Category");
        //    }
        //    return View(sp);

        //}

        //[Route("EditCategory")]
        //[HttpGet]
        //public IActionResult EditCategory(int id)
        //{
        //    var cate = db.Categories.Find(id);
        //    return View(cate);
        //}
        //[Route("EditCategory")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EditCategory(Category cate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Category", "HomeAdmin");
        //    }
        //    return View(cate);

        //}

    }
}
