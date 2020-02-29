using System.ComponentModel.DataAnnotations;
namespace OnlineCarParkingBookingManagement.Models
{
    public class CarOwnerViewModel
    {
            [DataType(DataType.Text)]
            public string name { get; set; }
            public string gender { get; set; }
            [DataType(DataType.PhoneNumber)]
            public long mobileNo { get; set; }
            [Display(Name = "address")]
            public string address { get; set; }
            [DataType(DataType.EmailAddress)]
            public string emailId { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "password")]
            public string password { get; set; }
            [Compare("password", ErrorMessage = "Password and Confirmation Password must match.")]
            public string conformPassword { get; set; }
            public string UserRole { get; set; }
        }
}