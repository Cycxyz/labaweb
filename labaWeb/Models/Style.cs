using System;
using System.Collections.Generic;

#nullable disable

namespace labaWeb
{
    public partial class Style
    {
        public Style()
        {
            BandToStyles = new HashSet<BandToStyle>();
        }

        public int StyleId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<BandToStyle> BandToStyles { get; set; }
    }
}
