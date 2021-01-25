using Cinema.Models;
using System.Linq;

namespace Cinema.Repositories.Abstruct
{
    public interface IUsersRepository
    {
        IQueryable<User> GetUsers();

        User GetUserById(string id);

        void SaveUser(User entity);
    }
}
