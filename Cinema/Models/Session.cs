using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Session
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public uint Hall { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

        public List<Ticket> Tickets { get; set; }

    }
}
