using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkWhere.Models
{
    public class Carpark
    {
        public string Number { get; set; }
        public int TotalLots { get; set; }
        public int AvailableLots { get; set; }
        public string LotType { get; set; }
    }
}
