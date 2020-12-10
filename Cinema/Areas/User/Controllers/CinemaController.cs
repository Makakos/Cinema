using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Areas.User.Controllers
{
    [Area("User")]
    public class CinemaController : Controller
    {
        private readonly DataManager manager;
        public CinemaController(DataManager dataManager) { manager = dataManager; }


        public IActionResult Tickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = manager.usersRepository.GetUserById(userId);
            user.Tickets = manager.ticketsRepository.GetUserTickets(userId);

            return View(user);
        }
    }
}
