using System.Collections.Generic;
using OnlineCarParkingBookingManagement.Entity;
namespace OnlineCarParkingBookingManagement.Repository
{
    public class CarOwnerDetailsRepository
    {
        public static List<CarOwnerDetails> carOwnerDetails = new List<CarOwnerDetails>();
        static CarOwnerDetailsRepository()
        {
            carOwnerDetails.Add(new CarOwnerDetails("Sara", "Female", 8778636133, "Chennai", "sara@gmail.com", "special*23", "special*23", Role.Customer));
            carOwnerDetails.Add(new CarOwnerDetails("Priya", "Female", 9865514335, "Pune", "priya@gmail.com", "priya@", "priya@", Role.CarParkingSiteOwner));
            carOwnerDetails.Add(new CarOwnerDetails("Jahnavi", "Female", 7094410201, "Bangalore", "jahnavi@gmail.com", "jahnavi*", "jahnavi*", Role.Customer));
        }
        public IEnumerable<CarOwnerDetails> GetCarOwnerDetails()
        {
            return carOwnerDetails;
        }
        public static void SignUp(CarOwnerDetails carOwnerInfo)
        {
            carOwnerDetails.Add(carOwnerInfo);
        }
    }
}
