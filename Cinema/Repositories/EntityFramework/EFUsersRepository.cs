using System.Linq;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using Cinema.Repositories.Abstruct;

namespace Cinema.Repositories.EntityFramework
{
    public class EFUsersRepository : IUsersRepository
    {
        private readonly ApplicationContext applicationContext;

        public EFUsersRepository(ApplicationContext context)
        {
            this.applicationContext = context;
        }

        public IQueryable<User> GetUsers()
        {
            return this.applicationContext.Users;
        }

        public User GetUserById(string id)
        {
            return this.applicationContext.Users.Include(x => x.Tickets).FirstOrDefault(x => x.Id == id);
        }

        public void SaveUser(User entity)
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
    }
}
