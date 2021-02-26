using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int? CustomerId { get; set; }
        public int Place { get; set; }
        public decimal Price { get; set; }
        public int ConcertId { get; set; }

        public virtual Concert Concert { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
