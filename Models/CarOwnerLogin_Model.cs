using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarParkingBookingManagement.Models
{
    public class CarOwnerLogin_Model
    {
        [Required(ErrorMessage ="Please enter your EmailId")]
        [DataType(DataType.EmailAddress)]
        public string emailId { get; set; }
        [Required(ErrorMessage ="Please enter your Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}