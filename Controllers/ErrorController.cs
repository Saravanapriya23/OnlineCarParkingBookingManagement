using System.Web.Mvc;
namespace OnlineCarParkingBookingManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult ErrorHandler()  //Method to handle the error
        {
            return View();
        }
    }
}