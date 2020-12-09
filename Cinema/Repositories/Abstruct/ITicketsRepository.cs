using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Repositories.Abstruct
{
    public interface ITicketsRepository
    {
        IQueryable<Ticket> GetTickets();
        List<Ticket> GetUserTickets(string id);
        Ticket GetTicketById(int id);
        void SaveTicket(Ticket entity);
        void DeleteTicketById(int id);
        void DeleteTicket(Ticket ticket);
    }
}
