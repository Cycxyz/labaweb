using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class Band
    {
        public Band()
        {
            BandToStyles = new HashSet<BandToStyle>();
            ConcertManToBands = new HashSet<ConcertManToBand>();
            ConcertToBands = new HashSet<ConcertToBand>();
        }

        public int BandId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BandToStyle> BandToStyles { get; set; }
        public virtual ICollection<ConcertManToBand> ConcertManToBands { get; set; }
        public virtual ICollection<ConcertToBand> ConcertToBands { get; set; }
    }
}
