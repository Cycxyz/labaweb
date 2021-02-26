using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class Customer
    {
        public Customer()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
