using Cinema.Models;
using Cinema.Repositories.Abstruct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Repositories.EntityFramework
{
    public class EFTicketsRepository:ITicketsRepository
    {
        private readonly ApplicationContext applicationContext;

        public EFTicketsRepository(ApplicationContext context)
        {
            this.applicationContext = context;
        }

        public IQueryable<Ticket> GetTickets()
        {
            return this.applicationContext.Tickets;
        }

        public List<Ticket> GetUserTickets(string id)
        {
            List<Ticket> result = new List<Ticket>();
            foreach (var el in this.applicationContext.Tickets.Include(x => x.Session).ThenInclude(x => x.Film).Where(x => x.UserId == id))
            {
                result.Add(el);
            }

            return result;
        }

        public Ticket GetTicketById(int id)
        {
            return this.applicationContext.Tickets.Include(x => x.Session).ThenInclude(x => x.Film).FirstOrDefault(x => x.Id == id);
        }

        public void SaveTicket(Ticket entity)
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

        public void DeleteTicketById(int id)
        {
            this.applicationContext.Tickets.Remove(new Ticket { Id = id });
            this.applicationContext.SaveChanges();
        }

        public void DeleteTicket(Ticket ticket)
        {
            this.applicationContext.Entry(ticket).State = EntityState.Deleted;
            this.applicationContext.SaveChanges();
        }
    }
}
