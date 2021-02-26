using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class ConcertToBand
    {
        public int ConcertToBandId { get; set; }
        public int ConcertId { get; set; }
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual Concert Concert { get; set; }
    }
}
