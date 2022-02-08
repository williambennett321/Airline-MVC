using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airline_MVC.Models
{
    public class AirlineStaff
    {
        [Key]
        public int EmployeeNum { get; set; }
        [Required]
        public string EmployeePosition { get; set; }
        [Required]
        public int EmployeeWage { get; set; }
    }
}
