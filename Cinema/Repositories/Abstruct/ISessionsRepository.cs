using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
