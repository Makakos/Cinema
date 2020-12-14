using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(AccountController));

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
            log.Info("User watched his tickets");
            return View(tickets);
        }

        [HttpGet]
        public IActionResult Download(int id)
        {

            Ticket ticket = manager.ticketsRepository.GetTicketById(id);
            string pathName = $"{ticket.Session.Film.Name}_" +
                          $"{ticket.Session.Date.Day}{ticket.Session.Date.ToString("MMM")}_" +
                          $"{ticket.Session.Date.Hour}h_{ticket.Session.Date.Minute}min_ticket";

            string data = $"Film:{ticket.Session.Film.Name}\n" +
                            $"Date:{ticket.Session.Date.Day}{ticket.Session.Date.ToString("MMM")}\n" +
                            $"Time:{ticket.Session.Date.TimeOfDay}\n" +
                            $"Row:{ticket.Row}\n" +
                            $"Place:{ticket.Place}\n" +
                            $"Hall:{ticket.Session.Hall}\n" +
                            $"Price:{ticket.Price} грн";
           

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer((typeof(Ticket)));
            Stream jsonSerealiseStream = new FileStream(pathName+".json", FileMode.OpenOrCreate);
            jsonSerializer.WriteObject(jsonSerealiseStream, ticket);
            jsonSerealiseStream.Close();


            using (MemoryStream memory = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(memory);
                writer.Write(data);
                writer.Flush();
                writer.Close();
                log.Info($"User downloaded ticket for the film {ticket.Session.Film.Name} on {ticket.Session.Date.Day}{ticket.Session.Date.ToString("MMM")}");
                return File(memory.ToArray(), "text/plain", pathName+".txt");
            }
          

        }

        [HttpGet]
        public IActionResult Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = manager.usersRepository.GetUserById(userId);
            log.Info("User viewed his profile page");
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
                log.Info("User changed information about him");
                return RedirectToAction("Profile","Account","/User");
            }
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            log.Info("User logged out");
            return RedirectToAction("Index", "Home","/");
        }




    }
}
