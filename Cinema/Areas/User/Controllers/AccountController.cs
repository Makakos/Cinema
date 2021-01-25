using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Security.Claims;

namespace Cinema.Areas.UserArea.Controllers
{
    [Area("User")]
    public class AccountController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AccountController));

        private readonly SignInManager<User> signInManager;
        private readonly DataManager manager;

        public AccountController(DataManager dataManager, SignInManager<User> signIn)
        {
            this.signInManager = signIn;
            this.manager = dataManager;
        }

        public IActionResult Tickets()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Ticket> tickets = this.manager.ticketsRepository.GetUserTickets(userId);
            Log.Info("User watched his tickets");
            return this.View(tickets);
        }

        [HttpGet]
        public IActionResult Download(int id)
        {

            Ticket ticket = this.manager.ticketsRepository.GetTicketById(id);
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

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Ticket));
            Stream jsonSerealiseStream = new FileStream(pathName + ".json", FileMode.OpenOrCreate);
            jsonSerializer.WriteObject(jsonSerealiseStream, ticket);
            jsonSerealiseStream.Close();

            using (MemoryStream memory = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(memory);
                writer.Write(data);
                writer.Flush();
                writer.Close();
                Log.Info($"User downloaded ticket for the film {ticket.Session.Film.Name} on {ticket.Session.Date.Day}{ticket.Session.Date.ToString("MMM")}");
                return this.File(memory.ToArray(), "text/plain", pathName + ".txt");
            }
        }

        [HttpGet]
        public IActionResult Profile()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = this.manager.usersRepository.GetUserById(userId);
            Log.Info("User viewed his profile page");
            return this.View(user);
        }

        [HttpPost]
        public IActionResult Profile(User tempUser)
        {

            if (this.ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                User user = this.manager.usersRepository.GetUserById(userId);

                user.UserName = tempUser.UserName;
                user.PhoneNumber = tempUser.PhoneNumber;
                user.Email = tempUser.Email;
                this.manager.usersRepository.SaveUser(user);
                Log.Info("User changed information about him");
                return this.RedirectToAction("Profile", "Account", "/User");
            }

            return this.View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync();
            Log.Info("User logged out");
            return Redirect(@"\Home\Index");
        }
    }
}
