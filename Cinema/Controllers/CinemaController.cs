using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Cinema.Controllers
{

    public class CinemaController : Controller
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CinemaController));
        private readonly DataManager dataManager;

        public CinemaController(DataManager manager)
        {
            this.dataManager = manager;
        }

        public IActionResult Films()
        {
            Log.Info("Films page was viewed");
            return this.View(this.dataManager);
        }

        public IActionResult Film(int id)
        {

            Film film = this.dataManager.filmsRepository.GetFilmById(id);
            Log.Info($"{film.Name} film page was viewed");
            return this.View(film);
        }

        public IActionResult Session(int id)
        {

            Session session = this.dataManager.sessionsRepository.GetSessionById(id);
            Log.Info($"Session in hall {session.Hall} for {session.Date} was viewed");
            return this.View(session);
        }
    }
}
