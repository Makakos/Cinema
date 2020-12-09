using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Repositories.Abstruct;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories.EntityFramework
{
    public class EFSessionsRepository: ISessionsRepository
    {
        private readonly ApplicationContext applicationContext;
        public EFSessionsRepository(ApplicationContext context)
        {
            applicationContext = context;
        }

        public IQueryable<Session> GetSessions()
        {
            return applicationContext.Sessions;
        }

        public Session GetSessionById(int id)
        {
            return applicationContext.Sessions.FirstOrDefault(x => x.Id == id);
        }

        public void SaveSession(Session entity)
        {
            if (entity.Id == default)
                applicationContext.Entry(entity).State = EntityState.Added;
            else
                applicationContext.Entry(entity).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }

        public void DeleteSessionById(int id)
        {
            applicationContext.Sessions.Remove(new Session { Id = id });
            applicationContext.SaveChanges();
        }

        public void DeleteSession(Session goal)
        {
            applicationContext.Entry(goal).State = EntityState.Deleted;
            applicationContext.SaveChanges();
        }
    }
}
