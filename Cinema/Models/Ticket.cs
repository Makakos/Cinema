using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cinema.Models
{
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

        [DataMember]
        [Display(Name = "Row")]
        public string Row { get; set; }

        [DataMember]
        [Display(Name = "Place")]
        public string Place { get; set; }

       
        public string UserId { get; set; }
        public User User { get; set; }

        public int SessionId { get; set; }
        [DataMember]
        public Session Session { get; set; }

    }
}
