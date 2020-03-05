using System;
using System.Collections.Generic;
using System.Text;

namespace GreatStore.Models
{
    public class BuyerItemVM : ItemVM
    {
        public ushort FreeUnits { get; set; }
        public ulong Units { get; set; }
        public double Weight { get; set; }
    }
}
