using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeTravel.Models
{
    public class Hotel
    {
        public long propertyID { get; set; }
        public string name { get; set; }
        public long geoId { get; set; }
        public int rating { get; set; }
        //public List<Rates> rates { get; set; }
    }
}
