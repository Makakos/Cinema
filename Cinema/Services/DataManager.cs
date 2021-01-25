using Cinema.Repositories.Abstruct;

namespace Cinema.Services
{
    public class DataManager
    {
        public IUsersRepository usersRepository;
        public ITicketsRepository ticketsRepository;
        public ISessionsRepository sessionsRepository;
        public IFilmsRepository filmsRepository;

        public object Users { get; internal set; }

        public DataManager()
        {

        }

        public DataManager(IUsersRepository usesrs,ITicketsRepository tickets,ISessionsRepository sessions,IFilmsRepository films)
        {
            this.usersRepository = usesrs;
            this.ticketsRepository = tickets;
            this.sessionsRepository = sessions;
            this.filmsRepository = films;
        }

    }
}
