using Cinema.Repositories.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Services
{
    public class DataManager
    {
        public IUsersRepository usersRepository;
        public ITicketsRepository ticketsRepository;
        public ISessionsRepository sessionsRepository;
        public IFilmsRepository filmsRepository;

        public DataManager(IUsersRepository usesrs,ITicketsRepository tickets,ISessionsRepository sessions,IFilmsRepository films)
        {
            usersRepository = usesrs;
            ticketsRepository = tickets;
            sessionsRepository = sessions;
            filmsRepository = films;
        }
    }
}
