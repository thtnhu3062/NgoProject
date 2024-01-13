using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NgoProject.Models;
using NgoProject.ViewModel;

namespace NgoProject.Controllers
{

    public class FeedBackController : Controller
    {
        private readonly NgoProjectContext db;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FeedBackController(NgoProjectContext db, IWebHostEnvironment hostEnvironment)
        {
            this.db = db;
            _hostEnvironment = hostEnvironment;
        }

        [Route("IndexFeedBack")]
        public IActionResult IndexFeedBack()
        {
            var content = db.Feedbacks.OrderBy(f => f.Name).ToList();
            return View(content);
        }


        //public async Task<IActionResult> IndexFeedBack(string searchString)
        //{
        //    var fb = from m in db.Feedbacks
        //                  select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        fb = fb.Where(s => s.Name!.Contains(searchString));
        //    }
        //    return View(await fb.ToListAsync());
        //}

        [Route("FeedBack")]
        [HttpGet]
        public IActionResult AddFeedBack()
        {
            return View();
        }


        [Route("FeedBack")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFeedBack(ViewModelFeedBack model)
        {
            if (ModelState.IsValid)
            {

                Feedback fb = new Feedback
                {
                    Name = model.Name,
                    FeedbackPhone = model.FeedbackPhone,
                    FeedbackEmail = model.FeedbackEmail,
                    FeedbackMessage = model.FeedbackMessage,
                };

                db.Feedbacks!.Add(fb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }


        [Route("DeleteFeedback")]
        public async Task<ActionResult> DeleteFeedback(int id)
        {
            var cus = await db.Feedbacks!.SingleOrDefaultAsync(x => x.FeedbackId == id);
            db.Feedbacks.Remove(cus!);
            db.SaveChanges();
            return RedirectToAction("IndexFeedBack", "HomeAdmin");
        }
    }
}
