using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cinema.Controllers
{

    public class HomeController : Controller
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly DataManager dataManager;

        public HomeController(DataManager manager)
        {
            this.dataManager = manager;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.dataManager.usersRepository.GetUserById(userId);
                this.ViewBag.UserName = user.UserName;
            }

            Log.Info("Home page was viewed");
            return this.View();
        }

        public IActionResult Privacy()
        {
            Log.Info("Privacy page was viewed");
            return this.View();
        }

    }
}
