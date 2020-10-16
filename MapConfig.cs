using AutoMapper;
using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.Entity;
using OnlineCarParkingBookingManagement.Models;
using System;
namespace OnlineCarParkingBookingManagement
{
    public class MapConfig
    {
        public static void MapCarOwnerDetails()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CarParkingSiteViewModel, ParkingSiteDetails>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.carParkingSiteId, opt => opt.MapFrom(src => ParkingSiteDetails.GenerateParkingSiteId(src.carParkingSiteName,src.carParkingSiteLocation)));
                config.CreateMap<ParkingSiteDetails, CarParkingSiteViewModel>();
                config.CreateMap<CarOwnerLogin_Model,CarOwnerDetails>();
                config.CreateMap<CarOwnerRegister_Model, CarOwnerDetails>();
            });
        }
    }
}