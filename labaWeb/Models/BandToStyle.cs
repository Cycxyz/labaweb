using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class BandToStyle
    {
        public int BandToStyleId { get; set; }
        public int StyleId { get; set; }
        public int BandId { get; set; }

        public virtual Band Band { get; set; }
        public virtual Style Style { get; set; }
    }
}
