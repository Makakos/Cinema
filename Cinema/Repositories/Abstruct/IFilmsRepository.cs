using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Repositories.Abstruct
{
    public interface IFilmsRepository
    {
        IQueryable<Film> GetFilms();
        Film GetFilmById(int id);
        void SaveFilm(Film entity);
        void DeleteFilmById(int id);
        void DeleteFilm(Film film);
    }
}
