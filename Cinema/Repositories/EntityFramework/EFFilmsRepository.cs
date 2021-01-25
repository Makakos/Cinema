using Cinema.Models;
using Cinema.Repositories.Abstruct;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cinema.Repositories.EntityFramework
{
    public class EFFilmsRepository:IFilmsRepository
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(EFFilmsRepository));
        private readonly ApplicationContext applicationContext;

        public EFFilmsRepository(ApplicationContext context)
        {
            this.applicationContext = context;
        }

        public IQueryable<Film> GetFilms()
        {
            try
            {
                return this.applicationContext.Films;
            }
            catch (SqlException ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }

        public Film GetFilmById(int id)
        {
            return this.applicationContext.Films.Include(x=>x.Sessions).FirstOrDefault(x => x.Id == id);
        }

        public void SaveFilm(Film entity)
        {
            if (entity.Id == default)
            {
                this.applicationContext.Entry(entity).State = EntityState.Added;
            }
            else
            {
                this.applicationContext.Entry(entity).State = EntityState.Modified;
            }

            this.applicationContext.SaveChanges();
        }

        public void DeleteFilmById(int id)
        {
            this.applicationContext.Films.Remove(new Film { Id = id });
            this.applicationContext.SaveChanges();
        }

        public void DeleteFilm(Film goal)
        {
            this.applicationContext.Entry(goal).State = EntityState.Deleted;
            this.applicationContext.SaveChanges();
        }
    }
}