using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.BL;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineCarParkingBookingManagement.Controllers
{
    public class ParkingSiteController : Controller
    {
        ParkingSiteDetailsRepository parkingSiteDetailsRepository = new ParkingSiteDetailsRepository();
        // GET: CarParkingSite
        ParkingSite_DetailsBL parkingSite_Details = new ParkingSite_DetailsBL();
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
        }//Action Method to display the parking site details to customer
        public ActionResult DisplayParkingSiteDetails()
        {
            try
            {
                IEnumerable<ParkingSiteDetails> carParkingSiteDetails = ParkingSiteDetailsRepository.DisplayParkingSiteDetails();
                TempData["carParkingSiteDetails"] = carParkingSiteDetails;
                return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        //Action Method to display parking site details to customer
        [Authorize(Roles = "User")]
        public ActionResult DisplayDetailsToCustomer()
        {
            try
            {

                IEnumerable<ParkingSiteDetails> carParkingSiteDetails = ParkingSiteDetailsRepository.DisplayParkingSiteDetails();
                TempData["carParkingSiteDetails"] = carParkingSiteDetails;
                return View();
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddParkingSiteDetails()
        {
            try
            {
                IEnumerable<ParkingSiteDetails> carParkingSiteDetails = parkingSite_Details.GetParkingSiteDetails();
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
        [ValidateAntiForgeryToken]  // To avoid Cross Site Request Forgery
        //[Authorize(Roles = "Admin")]
        public ActionResult AddParkingSiteDetails(CarParkingSiteViewModel carParking)
        {
            //try
            //{
            var car = AutoMapper.Mapper.Map<CarParkingSiteViewModel, ParkingSiteDetails>(carParking);
            if (ParkingSiteDetailsRepository.VerifyParkingSiteId(car.carParkingSiteId))                              //Verifying the existance of parking site
            {
                parkingSiteDetailsRepository.AddParkingSiteDetails(car);                      //Adding the parking site details to the database
                return RedirectToAction("DisplayParkingSiteDetails");                      //Redirecting after adding the parking site details                          
            }
            TempData["Message"] = "Parking ID already exists";                           //Displaying error message if the parking site is already is added
            //}
            //catch
            //{
            //    return RedirectToAction("ErrorHandler", "Error");
            //}
            return View();
        }
        [HttpGet]
        public ActionResult EditCarParkingSiteDetails(int Id)
        {
            ParkingSiteDetails carParkingSiteDetails = parkingSiteDetailsRepository.GetParkingSiteDetailsById(Id);
            return View(carParkingSiteDetails);
        }
        //Action Method to edit the Parking Site details
        [HttpPost]
        public ActionResult EditCarParkingSiteDetails(CarParkingSiteViewModel edit)
        {
            try
            {
                //CarParkingSiteViewModel carParkingSiteViewModel = GetParkingSiteDetailsById(edit.carId);
                ParkingSiteDetails carParkingSiteDetails = parkingSiteDetailsRepository.GetParkingSiteDetailsById(edit.carParkingSiteId);
                carParkingSiteDetails.carParkingSiteId = edit.carParkingSiteId;
                carParkingSiteDetails.carParkingSiteName = edit.carParkingSiteName;
                carParkingSiteDetails.carParkingSiteLocation = edit.carParkingSiteLocation;
                carParkingSiteDetails.parkingSlots = edit.parkingSlots;
                carParkingSiteDetails.emailId = edit.emailId;
                carParkingSiteDetails.UpdationDate = DateTime.Now;
                parkingSiteDetailsRepository.UpdateParkingSiteDetails(carParkingSiteDetails);
                return RedirectToAction("DisplayParkingSiteDetails");
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
        [HttpGet]
        public ActionResult DeleteCarParkingDetails(int Id)
        {
            ParkingSiteDetails carParkingSiteDetails = parkingSiteDetailsRepository.GetParkingSiteDetailsById(Id);
            return View(carParkingSiteDetails);
        }
        //Action method to delete the parking site details
        [HttpPost]
        public ActionResult DeleteCarParkingDetails(CarParkingSiteViewModel delete)
        {
            try
            {
                ParkingSiteDetails carParkingSiteDetails = new ParkingSiteDetails();
                carParkingSiteDetails.carParkingSiteId = delete.carParkingSiteId;
                parkingSiteDetailsRepository.DeleteParkingSiteDetails(carParkingSiteDetails);
                return RedirectToAction("DisplayParkingSiteDetails");
            }
            catch
            {
                return RedirectToAction("ErrorHandler", "Error");
            }
        }
    }
}