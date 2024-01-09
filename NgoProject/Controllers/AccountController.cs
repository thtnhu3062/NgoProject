using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using NgoProject.Models;
using NgoProject.ViewModel;
using NuGet.Common;
using QuickMailer;
using System.Text;
using System.Text.Encodings.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace NgoProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppModelUser> _userManager;
        private SignInManager<AppModelUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public AccountController(SignInManager<AppModelUser> signInManager, UserManager<AppModelUser> userManager, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;


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
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public async Task<IActionResult> Lock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var app = await _userManager.FindByIdAsync(id);
            if (app == null)
            {
                return NotFound();
            }
            app.LockoutEnd = DateTime.Now.AddYears(100);
            return RedirectToAction("ListUsers", "Account");
        }
        public async Task<IActionResult> UnLock(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var app = await _userManager.FindByIdAsync(id);
            if (app == null)
            {
                return NotFound();
            }
            app.LockoutEnd = DateTime.Now;
            await _userManager.UpdateAsync(app);
            return RedirectToAction("ListUsers", "Account");
        }

        //forgot password
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        private async Task SendForgotPasswordEmail(string? email, AppModelUser user)
        {
            // Generate the reset password token
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Build the password reset link which must include the Callback URL
            // Build the password reset link
            var passwordResetLink = Url.Action("ResetPassword", "Account",
                    new { Email = email, Token = token }, protocol: HttpContext.Request.Scheme);
            //Send the Confirmation Email to the User Email Id
            await _emailSender.SendEmailAsync(email, "Reset Your Password", $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(passwordResetLink)}'>clicking here</a>.");
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email
                var user = await _userManager.FindByEmailAsync(model.Email);
                // If the user is found AND Email is confirmed
                if (user != null && await _userManager.IsEmailConfirmedAsync(user))
                {
                    await SendForgotPasswordEmail(user.Email, user);
                    // Send the user to Forgot Password Confirmation view
                    return RedirectToAction("ForgotPasswordConfirmation", "Account");
                }
                // To avoid account enumeration and brute force attacks, don't
                // reveal that the user does not exist or is not confirmed
                return RedirectToAction("ForgotPassword", "Account");
            }
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}
