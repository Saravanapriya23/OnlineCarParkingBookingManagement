using System.ComponentModel.DataAnnotations;

namespace OnlineCarParkingBookingManagement.Entity
{
    public enum Role
    {
        Customer,
        CarParkingSiteOwner
    }
    public class CarOwnerDetails
    {
        [Display(Name = "name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string name { get; set; }
        public string gender { get; set; }
        [Required(ErrorMessage = "Phone number is Required")]
        [DataType(DataType.PhoneNumber)]
        public long mobileNo { get; set; }
        [Required]
        [Display(Name = "address")]
        public string address { get; set; }
        [Required(ErrorMessage = "Email address Required")]
        [DataType(DataType.EmailAddress)]
        public string emailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirmation Password is required.")]
        [Compare("password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string conformPassword { get; set; }
        public Role UserRole { get; set; }
        public CarOwnerDetails()
        {

        }
        public CarOwnerDetails(string Name, string Gender, long MobileNo, string location, string EmailId, string Password, string conformpassword, Role userrole)
        {
            name = name;
            gender = Gender;
            mobileNo = MobileNo;
            address = location;
            emailId = EmailId;
            password = Password;
            conformPassword = conformpassword;
            UserRole = userrole;
        }
    }
}
