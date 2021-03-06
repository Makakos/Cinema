﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cinema.Models
{
    [DataContract]
    public class Session
    {
        public int Id { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public uint Hall { get; set; }

        public int FilmId { get; set; }
        [DataMember]
        public Film Film { get; set; }

        public List<Ticket> Tickets { get; set; }

    }
}
