using Microsoft.AspNetCore.Mvc;
using NgoProject.Models;

namespace NgoProject.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
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

    }
}
