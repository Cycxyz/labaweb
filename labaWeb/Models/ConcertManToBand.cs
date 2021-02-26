using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class ConcertManToBand
    {
        public int ConcertManToBandId { get; set; }
        public int ConcertManId { get; set; }
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual ConcertMan ConcertMan { get; set; }
    }
}
