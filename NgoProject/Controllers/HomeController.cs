using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NgoProject.Models;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace NgoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly NgoProjectContext db ;

        public HomeController(NgoProjectContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            this._hostEnvironment = hostEnvironment;

        }

        public IActionResult Index()
        {
            var ltsnews = db.News.ToList();
            return View(ltsnews);
        }

    }
}
