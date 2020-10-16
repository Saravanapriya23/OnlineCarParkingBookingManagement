using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.BL;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineCarParkingBookingManagement.Controllers
{
    public class CarDetailsController : Controller
    {
        // GET: CarDetails
        CarDetailsRepository carDetailsRepository = new CarDetailsRepository();
        Car_DetailsBL car_Details = new Car_DetailsBL();
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
        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult AddCarDetails()
        {
            try
            {
                IEnumerable<CarDetails> carDetails = car_Details.GetCarDetails();
                return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
            //return View();
        }
        //Action Method to add the parking site details
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]  // To avoid Cross Site Request Forgery
        public ActionResult AddCarDetails(CarDetailsView_Model carParking)
        {
            var car = AutoMapper.Mapper.Map<CarDetailsView_Model, CarDetails>(carParking);
            carDetailsRepository.AddCarDetails(car);                      //Adding the service to the database
            return RedirectToAction("DisplayParkingSiteDetails");                      //Redirecting after adding the car details                           
        }
    }
}