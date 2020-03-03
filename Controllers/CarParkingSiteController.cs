using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.Models;
using OnlineCarParkingBookingManagement.Repository;
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
            //return View(carParkingSiteDetails);
        }
        [HttpGet]
        public ActionResult AddCarParkingDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCarParkingDetails(CarParkingSiteDetails carParking)
        {
            CarParkingSiteDetails carParkingSiteDetails = new CarParkingSiteDetails();
            carParkingSiteDetails.carId = carParking.carId;
            carParkingSiteDetails.carParkingSiteName = carParking.carParkingSiteName;
            carParkingSiteDetails.carParkingSiteLocation = carParking.carParkingSiteLocation;
            carParkingSiteDetails.parkingSlots = carParking.parkingSlots;
            carParkingSiteDetails.emailId = carParking.emailId;
            CarParkingSiteDetailsRepository.AddCarParkingDetails(carParkingSiteDetails);
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
            CarParkingSiteDetails carParkingSiteDetails = new CarParkingSiteDetails();
            carParkingSiteDetails.carId = edit.carId;
            carParkingSiteDetails.carParkingSiteName = edit.carParkingSiteName;
            carParkingSiteDetails.carParkingSiteLocation = edit.carParkingSiteLocation;
            carParkingSiteDetails.parkingSlots = edit.parkingSlots;
            carParkingSiteDetails.emailId = edit.emailId;
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