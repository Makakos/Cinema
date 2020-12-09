using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cost")]
        public string Cost { get; set; }

        [Display(Name = "Row")]
        public string Row { get; set; }

        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Task")]
        public string Title { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
