using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.BL;
using OnlineCarParkingBookingManagement.Repository;
namespace OnlineCarParkingBookingManagement.Controllers
{
    [HandleError]
    public class CarOwnerDetailsController : Controller
    {
        // GET: CarOwnerDetails
        CarOwner_Details carOwner_Details = new CarOwner_Details();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayCarOwnerDetails()
        {
            IEnumerable<CarOwnerDetails> carOwnerDetails = CarOwnerDetailsRepository.DisplayCarOwnerDetails();
            TempData["carOwnerDetails"] = carOwnerDetails;
            return View();
            //return View(carParkingSiteDetails);
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            IEnumerable<CarOwnerDetails> carOwnerDetails = carOwner_Details.CreateDB();
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_New(CarOwnerRegister_Model customerInfo)
        { 
            if (ModelState.IsValid)
            {
                CarOwnerDetails carOwnerInfo = new CarOwnerDetails
                {
                    CarOwnerName = customerInfo.CarOwnerName,
                    CarOwnerGender = customerInfo.CarOwnerGender,
                    CarOwnerMobileNo = customerInfo.CarOwnerMobileNo,
                    CarOwnerAddress = customerInfo.CarOwnerAddress,
                    CarOwnerEmailId = customerInfo.CarOwnerEmailId,
                    CarOwnerPassword = customerInfo.CarOwnerPassword,
                    UserRole = customerInfo.Role,
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
                carOwnerInfo.CarOwnerEmailId = carOwnerLogin_model.CarOwnerEmailId;
                carOwnerInfo.CarOwnerPassword = carOwnerLogin_model.CarOwnerPassword;
                string userRole = carOwner_Details.SignIn(carOwnerInfo);
                if (userRole == "User")
                {
                    TempData["message"] = "user Login successfull";
                    return RedirectToAction("DisplayDetailsToCustomer", "CarParkingSite");
                }
                else if (userRole == "Admin")
                {
                    ViewBag.message = "Admin Login Successful";
                    return RedirectToAction("DisplayCarParkingSiteDetails", "CarParkingSite");
                }
                else if (userRole == "ParkingSiteOwner")
                {
                    TempData["message"] = " Parking Site Owner Login successfull";
                    return RedirectToAction("DisplayCarParkingSiteDetails", "CarParkingSite");
                }
                else
                {
                    TempData["message"] = "Incorrect email Id or password";
                }
            }
            return View();
            //throw new Exception();
        }
        public ActionResult EditCarOwnerDetails(string emailId)
        {
            CarOwnerDetails carParkingSiteDetails = CarOwnerDetailsRepository.GetCarOwnerDetailsById(emailId);
            return View(carParkingSiteDetails);
        }
        [HttpPost]
        public ActionResult EditCarOwnerDetails(CarOwnerRegister_Model edit)
        {
            CarOwnerDetails carOwnerDetails = new CarOwnerDetails();
            carOwnerDetails.CarOwnerEmailId = edit.CarOwnerEmailId;
            carOwnerDetails.CarOwnerName = edit.CarOwnerName;
            carOwnerDetails.CarOwnerGender = edit.CarOwnerGender;
            carOwnerDetails.CarOwnerMobileNo = edit.CarOwnerMobileNo;
            carOwnerDetails.CarOwnerAddress = edit.CarOwnerAddress;
            CarOwnerDetailsRepository.UpdateCarOwnerDetails(carOwnerDetails);
            return RedirectToAction("DisplayCarParkingSiteDetails");
        }
        public ActionResult Home()
        {
            return RedirectToAction("Index", "CarOwnerDetails");
        }
    }
}