using System.Collections.Generic;
using System.Web.Mvc;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.BL;
using System.Web.Security;
using System;
using System.Web;

namespace OnlineCarParkingBookingManagement.Controllers
{
    [HandleError]
    public class CarOwnerDetailsController : Controller
    {
        // GET: CarOwnerDetails
        CarOwner_DetailsBL carOwner_Details = new CarOwner_DetailsBL();
        public ActionResult Index()
        {

            try
            {
                return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }

        }
        //Action Result method to Regsiter the new customer
        [HttpGet]
        public ActionResult SignUp()
        {
            try
            {
                IEnumerable<CarOwnerDetails> carOwnerDetails = carOwner_Details.GetCarOwnerDetails();
                return View();
            }
            catch
            {
                //return View();
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_New(CarOwnerRegister_Model customerInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CarOwnerDetails carOwnerInfo = new CarOwnerDetails
                    {
                        FirstName = customerInfo.FirstName,
                        LastName = customerInfo.LastName,
                        Gender = customerInfo.Gender,
                        MobileNo = customerInfo.MobileNo,
                        Address = customerInfo.Address,
                        EmailId = customerInfo.EmailId,
                        Password = customerInfo.Password,
                        UserRole = customerInfo.Role,
                    };
                    carOwner_Details.Add(carOwnerInfo);
                    return RedirectToAction("SignIn");       //Registered successfully means it will redirect to the login page
                }
                TempData["message"] = "registered successfull..";
                return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        public ActionResult SignIn()
        {
            return View();
        }
        //Action method to login into the Car Parking Site
        [HttpPost]
        [ActionName("SignIn")]
        public ActionResult SignIn_New(CarOwnerLogin_Model carOwnerLogin_model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                 CarOwnerDetails carOwnerInfo = AutoMapper.Mapper.Map<CarOwnerLogin_Model, CarOwnerDetails>(carOwnerLogin_model);
                 CarOwnerDetails user = carOwner_Details.SignIn(carOwnerInfo); //Validate login details
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.EmailId, false);
                    var authTicket = new FormsAuthenticationTicket(1, user.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.UserRole);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "ParkingSite");
                }
                else
                        TempData["message"] = "Incorrect email Id or password";
                }
            return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        public ActionResult Home()
        {
            try
            {
                return RedirectToAction("Index", "CarOwnerDetails");
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "CarOwnerDetails");
        }

    }
}