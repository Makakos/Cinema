using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Repositories.Abstruct
{
    public interface IUsersRepository
    {
        IQueryable<User> GetUsers();
        User GetUserById(string id);
        void SaveUser(User entity);
    }
}
