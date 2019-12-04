using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesomeTravel.Repositories.Classes
{
    public class Hotel
    {
        public long propertyID { get; set; }
        public string name { get; set; }
        public long geoId { get; set; }
        public int rating { get; set; }
    }
}
