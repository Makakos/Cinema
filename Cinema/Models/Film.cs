using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cinema.Models
{
    [DataContract]
    public class Film
    {
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public TimeSpan Runtime { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public string DirectorName { get; set; }

        public string DirectorLastName { get; set; }

        public string PosterImagePath { get; set; }

        public List<Session> Sessions { get; set; }
    }
}
