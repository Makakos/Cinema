using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Cinema.Controllers
{
   
    public class AccountController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccountController));
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

       

        [HttpGet]
        public IActionResult Registration()
        {
            log.Info("Registration started");
            return View(new RegistrationViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {

                User user = new User { UserName = (model.Name == null ? model.Email : model.Name), Years = model.Year, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(user, "User");
                    log.Info("User was registrated");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        log.Error(error.Description);
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnURL = returnUrl;
            log.Info("Loggin started");
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
                    if (result.Succeeded)
                    {
                        log.Info("User successfuly logged in");
                        return Redirect(returnUrl ?? "/");
                    }
                }
                log.Error("User entered wrong login or password");
                ModelState.AddModelError(nameof(LoginViewModel), "Неверный логин или пароль");
            }
            return View(model);
        }



        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            log.Info("User logged out");
            return RedirectToAction("Index", "Home");
        }

    }
}

