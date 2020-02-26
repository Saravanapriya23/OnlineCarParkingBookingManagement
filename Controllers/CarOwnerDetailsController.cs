using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Repository;

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
            CarOwnerDetails carOwnerInfo = new CarOwnerDetails();
            TryUpdateModel(carOwnerInfo);
            CarOwnerDetailsRepository.SignUp(carOwnerInfo);
            return View();
        }
    }
}