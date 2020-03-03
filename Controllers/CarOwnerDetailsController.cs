using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.BL;

namespace OnlineCarParkingBookingManagement.Controllers
{
    [HandleError]
    public class CarOwnerDetailsController : Controller
    {
        // GET: CarOwnerDetails
        CarOwner_Details carOwner_Details = new CarOwner_Details();
        //public CarOwnerDetailsController()
        //{
        //    carownerdetails = new CarOwnerDetailsRepository();
        //}
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            IEnumerable<CarOwnerDetails> carOwnerDetails = carOwner_Details.CreateDB();
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_New(CarOwnerViewModel customerInfo)
        {
            if (ModelState.IsValid)
            {
                CarOwnerDetails carOwnerInfo = new CarOwnerDetails
                {
                    name = customerInfo.name,
                    gender = customerInfo.gender,
                    mobileNo = customerInfo.mobileNo,
                    address = customerInfo.address,
                    emailId = customerInfo.emailId,
                    password = customerInfo.password,
                    userRole = "User"
                };
                carOwner_Details.Add(carOwnerInfo);
                return RedirectToAction("SignIn");
            }
            TempData["message"] = "registered successfull..";
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult SignIn_New(CarOwnerLogin_Model carOwnerLogin_model)
        {
            if (ModelState.IsValid)
            {
                CarOwnerDetails carOwnerInfo = new CarOwnerDetails();
                carOwnerInfo.emailId = carOwnerLogin_model.emailId;
                carOwnerInfo.password = carOwnerLogin_model.password;
                string userRole = carOwner_Details.SignIn(carOwnerInfo);
                if (userRole == "User")
                {
                    TempData["message"] = "user Login successfull";
                    return RedirectToAction("DisplayCarParkingSiteDetails", "CarParkingSite");
                }
                else if (userRole == "Admin")
                {
                    TempData["message"] = " Admin Login successfull";
                    return RedirectToAction("DisplayCarParkingSiteDetails", "CarParkingSite");
                }
                TempData["message"] = "Incorrect email Id or password";
            }
                return View();
        }
    }
}