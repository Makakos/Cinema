using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Cinema.Models
{
    public class User : IdentityUser
    {
        public int Years { get; set; }

        public List<Ticket> Tickets { get; set; }

    }
}
