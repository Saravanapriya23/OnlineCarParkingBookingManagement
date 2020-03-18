using System.ComponentModel.DataAnnotations;
namespace OnlineCarParkingBookingManagement.Models
{
    public class CarOwnerRegister_Model
    {
        [Required(ErrorMessage = "Name required")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        [RegularExpression(@"(^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$)", ErrorMessage = "Invalid Name")]
        public string CarOwnerName { get; set; }
        [Required(ErrorMessage = "Gender required")]
        public string CarOwnerGender { get; set; }
        [Required(ErrorMessage = "Phone number required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Enter the numeric digits.")]
        public long CarOwnerMobileNo { get; set; }
        [Required(ErrorMessage = "The address is required")]
        public string CarOwnerAddress { get; set; }
        [Key]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CarOwnerEmailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        [RegularExpression("((?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()]).{6,15})")]
        public string CarOwnerPassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("CarOwnerPassword", ErrorMessage = "Password and Confirm password must be same")]
        public string conformPassword { get; set; }
        public string Role { get; set; }
        
    }
}