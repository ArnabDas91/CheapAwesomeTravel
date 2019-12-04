using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CheapAwesomeTravel.Models
{
    public class Tour
    {
        [Required(ErrorMessage ="Please Select Destination")]
        public int DestinationId { get; set; }
        [Required(ErrorMessage = "Please Enter No of Nights")]
        [Range(1,99,ErrorMessage ="No of Nights Must Be Greater Than Zero and Less Than 100")]
        public int Nights { get; set; }
        [Required(ErrorMessage = "Please Enter Secret Authentication Code")]
        public string Code { get; set; }
    }
}
