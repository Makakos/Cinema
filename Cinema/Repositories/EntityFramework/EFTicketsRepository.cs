using Cinema.Models;
using Cinema.Repositories.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Repositories.EntityFramework
{
    public class EFTicketsRepository:ITicketsRepository
    {
        private readonly ApplicationContext applicationContext;
        public EFTicketsRepository(ApplicationContext context)
        {
            applicationContext = context;
        }

        public IQueryable<Ticket> GetTickets()
        {
            return applicationContext.Tickets;
        }

        public List<Ticket> GetUserTickets(string id)
        {
            List<Ticket> result = new List<Ticket>();
            foreach (var el in applicationContext.Tickets.Include(x => x.Session).ThenInclude(x => x.Film).Where(x => x.UserId == id))
                result.Add(el);
            return result;
        }

        public Ticket GetTicketById(int id)
        {
            return applicationContext.Tickets.Include(x=>x.Session).ThenInclude(x=>x.Film).FirstOrDefault(x => x.Id == id);
        }

        public void SaveTicket(Ticket entity)
        {
            if (entity.Id == default)
                applicationContext.Entry(entity).State = EntityState.Added;
            else
                applicationContext.Entry(entity).State = EntityState.Modified;
            applicationContext.SaveChanges();
        }

        public void DeleteTicketById(int id)
        {
            applicationContext.Tickets.Remove(new Ticket { Id = id });
            applicationContext.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            applicationContext.Entry(ticket).State = EntityState.Deleted;
            applicationContext.SaveChanges();
        }
    }
}
