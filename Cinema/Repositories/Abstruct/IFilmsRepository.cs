using Cinema.Models;
using System.Linq;

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
