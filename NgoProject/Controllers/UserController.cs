using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NgoProject.Context;
using NgoProject.Models;
using NgoProject.ViewModel;
using QuickMailer;


namespace NgoProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext db;
        private readonly IWebHostEnvironment env;

        public UserController(DatabaseContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        
        [HttpGet]
        public  IActionResult Index()
        {
 
            return View(new Models.Ienumerable
            {
                Bn1 = db.banner?.ToList(),
                Bn2 = db.banners?.ToList()
            });
            
           
        }
     
        [HttpGet]
        public IActionResult SendFeedBack()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendFeedBack(SendFeedback send)
        {
            try
            {
                string msg = "Email Send Failed";
                Email email = new Email();
                bool isSend = email.SendEmail(send.To, Credential.Email, Credential.Password, send.Subject, send.Body);
                if (isSend)
                {
                    msg = "Email has been send";

                }
                ViewBag.msg = msg;
                RedirectToAction("Index", "User");  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
  
        
        public IActionResult Donate()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

       
        
     

      
    }
}
