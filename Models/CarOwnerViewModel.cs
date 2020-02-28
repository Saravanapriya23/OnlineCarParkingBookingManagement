using System.ComponentModel.DataAnnotations;
namespace OnlineCarParkingBookingManagement.Models
{
    public enum Role
    {
        Customer,
        CarParkingSiteOwner
    }
    public class CarOwnerViewModel
    {
            [DataType(DataType.Text)]
            [Required]
            [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Enter valid name")]
            public string name { get; set; }
            [Required]
            public string gender { get; set; }
            [DataType(DataType.PhoneNumber)]
            [Required]
            public long mobileNo { get; set; }
            [Required]
            [Display(Name = "address")]
            public string address { get; set; }
            [DataType(DataType.EmailAddress)]
            [Required]
            [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
            public string emailId { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "password")]
            public string password { get; set; }
            [Required(ErrorMessage = "Confirmation Password is required.")]
            [Compare("password", ErrorMessage = "Password and Confirmation Password must match.")]
            public string conformPassword { get; set; }
            public Role UserRole { get; set; }
        }
}