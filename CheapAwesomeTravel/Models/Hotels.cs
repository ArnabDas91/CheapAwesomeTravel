using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeTravel.Models
{
    public class Hotels
    {
        public Hotel Hotel { get; set; }
        public List<Rates> Rates { get; set; } = new List<Rates>();
    }
}
