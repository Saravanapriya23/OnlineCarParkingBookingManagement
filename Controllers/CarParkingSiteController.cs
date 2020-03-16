using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.Repository;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineCarParkingBookingManagement.Controllers
{
    public class CarParkingSiteController : Controller
    {
        // GET: CarParkingSite
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult DisplayCarParkingSiteDetails()
        {
            IEnumerable<CarParkingSiteDetails> carParkingSiteDetails = CarParkingSiteDetailsRepository.DisplayCarParkingSiteDetails();
            TempData["carParkingSiteDetails"] = carParkingSiteDetails;
            return View();
        }
        public ActionResult DisplayDetailsToCustomer()
        {
            IEnumerable<CarParkingSiteDetails> carParkingSiteDetails = CarParkingSiteDetailsRepository.DisplayCarParkingSiteDetails();
            TempData["carParkingSiteDetails"] = carParkingSiteDetails;
            return View();
        }
        [HttpGet]

        public ActionResult AddCarParkingDetails()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarParkingDetails(CarParkingSiteViewModel carParking)
        {
            var car = AutoMapper.Mapper.Map<CarParkingSiteViewModel, CarParkingSiteDetails>(carParking);
            CarParkingSiteDetailsRepository.AddCarParkingDetails(car);
            return RedirectToAction("DisplayCarParkingSiteDetails");
        }
        [HttpGet]
        public ActionResult EditCarParkingSiteDetails(int Id)
        {
            CarParkingSiteDetails carParkingSiteDetails = CarParkingSiteDetailsRepository.GetParkingSiteDetailsById(Id);
            return View(carParkingSiteDetails);
        }
        [HttpPost]
        public ActionResult EditCarParkingSiteDetails(CarParkingSiteViewModel edit)
        {
            //CarParkingSiteViewModel carParkingSiteViewModel = GetParkingSiteDetailsById(edit.carId);
            CarParkingSiteDetails carParkingSiteDetails = CarParkingSiteDetailsRepository.GetParkingSiteDetailsById(edit.carId);
            carParkingSiteDetails.carId = edit.carId;
            carParkingSiteDetails.carParkingSiteName = edit.carParkingSiteName;
            carParkingSiteDetails.carParkingSiteLocation = edit.carParkingSiteLocation;
            carParkingSiteDetails.parkingSlots = edit.parkingSlots;
            carParkingSiteDetails.emailId = edit.emailId;
            carParkingSiteDetails.UpdationDate = DateTime.Now;
            CarParkingSiteDetailsRepository.UpdateCarParkingDetails(carParkingSiteDetails);
            return RedirectToAction("DisplayCarParkingSiteDetails");
        }
        [HttpGet]
        public ActionResult DeleteCarParkingDetails(int Id)
        {
            CarParkingSiteDetails carParkingSiteDetails = CarParkingSiteDetailsRepository.GetParkingSiteDetailsById(Id);
            return View(carParkingSiteDetails);
        }
        [HttpPost]
        public ActionResult DeleteCarParkingDetails(CarParkingSiteViewModel delete)
        {
            CarParkingSiteDetails carParkingSiteDetails = new CarParkingSiteDetails();
            carParkingSiteDetails.carId = delete.carId;
            CarParkingSiteDetailsRepository.DeleteCarParkingDetails(carParkingSiteDetails);
            return RedirectToAction("DisplayCarParkingSiteDetails");
        }
    }
}