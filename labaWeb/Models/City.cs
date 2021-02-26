using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class City
    {
        public City()
        {
            ConcertAdresses = new HashSet<ConcertAdress>();
        }

        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ConcertAdress> ConcertAdresses { get; set; }
    }
}
