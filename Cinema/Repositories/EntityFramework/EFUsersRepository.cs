
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Cinema.Models;
using Cinema.Repositories.Abstruct;

namespace Cinema.Repositories.EntityFramework
{
    public class EFUsersRepository : IUsersRepository
    {
        private readonly ApplicationContext applicationContext;
        public EFUsersRepository(ApplicationContext context)
        {
            applicationContext = context;
        }

        public IQueryable<User> GetUsers()
        {
            return applicationContext.Users;
        }
        public User GetUserById(string id)
        {
            return applicationContext.Users.FirstOrDefault(x => x.Id == id);
        }


        public void SaveUser(User entity)
        {
            if (entity.Id == default)
                applicationContext.Entry(entity).State = EntityState.Added;
            else
                applicationContext.Entry(entity).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }


    }
}
