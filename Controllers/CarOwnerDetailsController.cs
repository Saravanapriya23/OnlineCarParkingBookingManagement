using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult SignUp(CarOwnerDetails carOwnerInfo)
        {
            CarOwnerDetailsRepository.SignUp(carOwnerInfo);
            return View();
        }
    }
}