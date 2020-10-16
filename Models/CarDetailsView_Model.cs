using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarParkingBookingManagement.Models
{
    public class CarDetailsView_Model
    {

        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid Company name")] 
        public string CompanyName { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid Model name")]
        public string Model { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid colour")]
        public string Colour { get; set; }
        [Key]
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@" (([A - Za - z]){2,3}(|-)(?:[0-9]){1,2}(|-)(?:[A-Za-z]){2}(|-)([0 - 9]){1,4})|(([A - Za - z]){2,3}(|-)([0 - 9]){1,4})", ErrorMessage = "Enter valid Registration Number")]
        public string Reg_Number { get; set; }
    }
}