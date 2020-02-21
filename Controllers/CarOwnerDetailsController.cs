using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Repository;

namespace OnlineCarParkingBookingManagement.Controllers
{
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
            IEnumerable<CarOwnerDetails> carOwnerDetails = carownerdetails.GetCarOwnerDetails();
            return View(carownerdetails);
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
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