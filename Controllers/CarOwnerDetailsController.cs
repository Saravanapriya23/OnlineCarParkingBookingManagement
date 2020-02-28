using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Repository;
using OnlineCarParkingBookingManagement.Models;
namespace OnlineCarParkingBookingManagement.Controllers
{
    [HandleError]
    public class CarOwnerDetailsController : Controller
    {
        // GET: CarOwnerDetails
        CarOwnerDetailsRepository carownerdetails;
        public CarOwnerDetailsController()
        {
            carownerdetails = new CarOwnerDetailsRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {

            IEnumerable<CarOwnerDetails> carOwnerDetails = CarOwnerDetailsRepository.GetCarOwnerDetails();
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_New()
        {
            CarOwnerViewModel customerInfo = new CarOwnerViewModel();
            TryUpdateModel(customerInfo);
            CarOwnerDetails carOwnerInfo = new CarOwnerDetails();
            carOwnerInfo.name = customerInfo.name;
            carOwnerInfo.gender = customerInfo.gender;
            carOwnerInfo.mobileNo = customerInfo.mobileNo;
            carOwnerInfo.address = customerInfo.address;
            carOwnerInfo.emailId = customerInfo.emailId;
            carOwnerInfo.password = customerInfo.password;
            CarOwnerDetailsRepository.SignUp(carOwnerInfo);
            return View();
        }
    }
}