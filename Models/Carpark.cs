using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarparkWhere.Models
{
    public class Carpark
    {
        public string Number { get; set; }
        public string TotalLots { get; set; }
        public string AvailableLots { get; set; }
        public string LotType { get; set; }
    }
}
