using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace OnlineCarParkingBookingManagement.Models
{
    public class CarParkingSiteViewModel
    {
        public int carId { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid parking site name")]
        public string carParkingSiteName { get; set; }
        [Required]
        [Display(Name = "carParkingSiteLocation")]
        public string carParkingSiteLocation { get; set; }
        public int parkingSlots { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string emailId { get; set; }
    }
}