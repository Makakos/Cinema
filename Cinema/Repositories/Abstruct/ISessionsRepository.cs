using Cinema.Models;
using System.Linq;

namespace Cinema.Repositories.Abstruct
{
    public interface ISessionsRepository
    {
        IQueryable<Session> GetSessions();

        Session GetSessionById(int id);

        void SaveSession(Session entity);

        void DeleteSessionById(int id);

        void DeleteSession(Session film);
    }
}
