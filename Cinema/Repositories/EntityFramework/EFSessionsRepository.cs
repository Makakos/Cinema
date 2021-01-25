using Cinema.Models;
using System.Linq;
using Cinema.Repositories.Abstruct;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repositories.EntityFramework
{
    public class EFSessionsRepository: ISessionsRepository
    {
        private readonly ApplicationContext applicationContext;

        public EFSessionsRepository(ApplicationContext context)
        {
            this.applicationContext = context;
        }

        public IQueryable<Session> GetSessions()
        {
            return this.applicationContext.Sessions;
        }

        public Session GetSessionById(int id)
        {
            return this.applicationContext.Sessions.Include(x=>x.Tickets).FirstOrDefault(x => x.Id == id);
        }

        public void SaveSession(Session entity)
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

        public void DeleteSessionById(int id)
        {
            this.applicationContext.Sessions.Remove(new Session { Id = id });
            this.applicationContext.SaveChanges();
        }

        public void DeleteSession(Session goal)
        {
            this.applicationContext.Entry(goal).State = EntityState.Deleted;
            this.applicationContext.SaveChanges();
        }
    }
}
