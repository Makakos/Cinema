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
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AccountController));
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
            Log.Info("Registration started");
            return this.View(new RegistrationViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (this.ModelState.IsValid)
            {

                User user = new User { UserName = model.Name == null ? model.Email : model.Name, Years = model.Year, Email = model.Email, PhoneNumber = model.PhoneNumber };
                var result = await this.userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await this.userManager.AddToRoleAsync(user, "User");
                    Log.Info($"User {user.UserName} was registrated");
                    await this.signInManager.SignInAsync(user, false);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        Log.Error(error.Description);
                        this.ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            this.ViewBag.ReturnURL = returnUrl;
            Log.Info("Login started");
            return this.View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                User user = await this.userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await this.signInManager.SignOutAsync();
                    var result = await this.signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);
                    if (result.Succeeded)
                    {
                        Log.Info($"User {user.UserName} successfuly logged in");
                        return this.Redirect(returnUrl ?? "/");
                    }
                }

                Log.Error("User entered wrong login or password");
                this.ModelState.AddModelError(nameof(LoginViewModel), "Wrong login or password");
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync();
            Log.Info("User logged out");
            return this.RedirectToAction("Index", "Home");
        }
    }
}