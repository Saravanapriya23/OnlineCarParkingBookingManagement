using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineCarParkingBookingManagement.Models
{
    public class CarParkingSiteViewModel
    {
        [Key]
        public int carParkingSiteId { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid parking site name")]
        public string carParkingSiteName { get; set; }
        [Required]
        [Display(Name = "carParkingSiteLocation")]
        [MaxLength(20)]
        public string carParkingSiteLocation { get; set; }
        public int parkingSlots { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string emailId { get; set; }
        [Display(Name = "CreationDate")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "UpdationDate")]
        public DateTime UpdationDate { get; set; }
    }
}