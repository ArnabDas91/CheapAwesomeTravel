using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeTravel.Models
{
    public class HotelDetails
    {
        public string HotelName { get; set; }
        public string BoardType { get; set; }
        public string RateType { get; set; }
        public double Price { get; set; }
        public int Nights { get; set; }
    }
}
