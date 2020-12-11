using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cinema.Models;
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Ticket> tickets = manager.ticketsRepository.GetUserTickets(userId);
            
            return View(tickets);
        }
    }
}
