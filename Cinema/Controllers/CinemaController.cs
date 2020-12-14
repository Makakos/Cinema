using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CinemaController));
         
        DataManager dataManager;
        public CinemaController(DataManager manager)
        { 
            dataManager = manager;
        }


        public IActionResult Films()
        {
            log.Info("Films page was viewed");
            return View(dataManager);
        }

        public IActionResult Film(int id)
        {

            Film film = dataManager.filmsRepository.GetFilmById(id);
            log.Info($"{film.Name} film page was viewed");
            return View(film);
        }

        public IActionResult Session(int id)
        {
            
            Session session = dataManager.sessionsRepository.GetSessionById(id);
            log.Info($"Session in hall {session.Hall} for {session.Date} was viewed");
            return View(session);
        }
    }
}
