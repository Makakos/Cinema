using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Film
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public string DirectorName { get; set; }

        public string DirectorLastName { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
