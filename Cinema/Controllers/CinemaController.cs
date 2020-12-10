using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        DataManager dataManager;
        public CinemaController(DataManager manager) { dataManager = manager; }


        public IActionResult Films()
        {
            return View(dataManager);
        }

        public IActionResult Film(int id)
        {
            Film film = dataManager.filmsRepository.GetFilmById(id);
            return View(film);
        }
    }
}
