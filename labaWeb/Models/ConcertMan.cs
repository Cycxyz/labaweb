using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class ConcertMan
    {
        public ConcertMan()
        {
            ConcertManToBands = new HashSet<ConcertManToBand>();
        }

        public int ConcertManId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<ConcertManToBand> ConcertManToBands { get; set; }
    }
}
