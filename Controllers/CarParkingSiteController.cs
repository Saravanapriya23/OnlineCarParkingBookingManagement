using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.Repository;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineCarParkingBookingManagement.Controllers
{
    public class CarParkingSiteController : Controller
    {
        // GET: CarParkingSite
        CarParkingSiteDetailsRepository carparkingsitedetails;
        public CarParkingSiteController()
        {
            carparkingsitedetails = new CarParkingSiteDetailsRepository();
        }
        // GET: CarParkingSite
        public ActionResult Index()
        {
            IEnumerable<CarParkingSiteDetails> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            // ViewBag.carparkingBookings = carparkingBookings;
            return View(carparkingsitedetails);

        }
        public ActionResult DataPassing()
        {
            IEnumerable<CarParkingSiteDetails> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            ViewBag.carparkingBookings = carparkingBookings;
            ViewData["carparkingBookings"] = carparkingBookings;
            TempData["carparkingBookings"] = carparkingBookings;
            return RedirectToAction("TempDataCheck");
        }
        public ActionResult TempDataCheck()
        {
            IEnumerable<CarParkingSiteDetails> carparkingBookings = carparkingsitedetails.GetCarParkingSiteDetails();
            TempData["carparkingBookings"] = carparkingBookings;
            return View();
        }
        public ActionResult Display()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CarParkingSiteDetails carParking)
        {
            carparkingsitedetails.Add(carParking);
            TempData["Result"] = "Added successfully";
            return RedirectToAction("TempDataCheck");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            CarParkingSiteDetails carParking = carparkingsitedetails.GetParkingSiteDetailsById(id);
            return View(carParking);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            CarParkingSiteDetails carParking = carparkingsitedetails.GetParkingSiteDetailsById(id);
            return View(carParking);
        }
        public ActionResult Update([Bind(Include = "carId, carParkingSiteName, carParkingSiteLocation")] CarParkingSiteDetails carParking)
        {
            carparkingsitedetails.UpdateCarParkingDetails(carParking);
            TempData["Result"] = "Added successfully";
            return RedirectToAction("TempDataCheck");
        }
    }
}