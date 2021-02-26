using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class ConcertAdress
    {
        public ConcertAdress()
        {
            Concerts = new HashSet<Concert>();
        }

        public int ConcertAdressId { get; set; }
        public string Details { get; set; }
        public int CityId { get; set; }
        public string Adress { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Concert> Concerts { get; set; }
    }
}
