﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineCarParkingBookingManagement.Models
{
    public class CarOwnerLogin_Model
    {
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string emailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
    }
}