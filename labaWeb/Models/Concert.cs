using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class Concert
    {
        public Concert()
        {
            ConcertToBands = new HashSet<ConcertToBand>();
            Tickets = new HashSet<Ticket>();
        }

        public int ConcertId { get; set; }
        public int ConcertAdressId { get; set; }
        public DateTime Date { get; set; }

        public virtual ConcertAdress ConcertAdress { get; set; }
        public virtual ICollection<ConcertToBand> ConcertToBands { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
