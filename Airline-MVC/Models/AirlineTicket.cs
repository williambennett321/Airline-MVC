using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_MVC.Models
{
    public class AirlineTicket
    {
        [Key]
        public int TicketNum { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string InitialAirport { get; set; }
        [Required]
        public string LandingAirport { get; set; }







    }
}
