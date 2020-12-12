using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Cinema.Areas.UserArea.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly DataManager manager;
        public AccountController(DataManager dataManager, SignInManager<User> signIn)
        {
            signInManager = signIn;
            manager = dataManager; 
        }


        public IActionResult Tickets()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Ticket> tickets = manager.ticketsRepository.GetUserTickets(userId);
            
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = manager.usersRepository.GetUserById(userId);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User tempUser)
        {

            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User user = manager.usersRepository.GetUserById(userId);

                user.UserName = tempUser.UserName;
                user.PhoneNumber = tempUser.PhoneNumber;
                user.Email = tempUser.Email;
                manager.usersRepository.SaveUser(user);

                return RedirectToAction("Profile","Account","/User");
            }
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
