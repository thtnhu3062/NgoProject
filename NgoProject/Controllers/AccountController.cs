using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using NgoProject.Models;
using NgoProject.ViewModel;
using QuickMailer;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace NgoProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppModelUser> _userManager;
        private SignInManager<AppModelUser> _signInManager;
        public AccountController(SignInManager<AppModelUser> signInManager, UserManager<AppModelUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public IActionResult Login(string returnUrl)
    
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName,loginVM.UserPassword, false,false);
                if (result.Succeeded)
                {
                    return Redirect(loginVM.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Uername or Password false");
            }
            return View(loginVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppModelUser newUser = new AppModelUser { UserName = user.UserName, Email = user.UserEmail, PhoneNumber = user.UserPhone};
                IdentityResult result = await _userManager.CreateAsync(newUser,user.UserPassword);
                if (result.Succeeded)
                {
                    return Redirect("/Account/Login");
                }
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(user);
        }

        public async Task<IActionResult> Logout(string returnUrl ="/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
