using Cinema.Models;
using Cinema.Repositories.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Repositories.EntityFramework
{
    public class EFFilmsRepository:IFilmsRepository
    {
        private readonly ApplicationContext applicationContext;
        public EFFilmsRepository(ApplicationContext context)
        {
            applicationContext = context;
        }

        public IQueryable<Film> GetFilms()
        {
            return applicationContext.Films;
        }

        public Film GetFilmById(int id)
        {
            return applicationContext.Films.Include(x=>x.Sessions).FirstOrDefault(x => x.Id == id);
        }

        public void SaveFilm(Film entity)
        {
            if (entity.Id == default)
                applicationContext.Entry(entity).State = EntityState.Added;
            else
                applicationContext.Entry(entity).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }

        public void DeleteFilmById(int id)
        {
            applicationContext.Films.Remove(new Film { Id = id });
            applicationContext.SaveChanges();
        }

        public void DeleteFilm(Film goal)
        {
            applicationContext.Entry(goal).State = EntityState.Deleted;
            applicationContext.SaveChanges();
        }
    }
}

