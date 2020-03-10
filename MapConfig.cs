using AutoMapper;
using OnlineCarParkingBookingManagament.Entity;
using OnlineCarParkingBookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCarParkingBookingManagement
{
    public class MapConfig
    {
        public static void MapCarOwnerDetails()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<CarParkingSiteViewModel, CarParkingSiteDetails>().ForMember(dest => dest.emailId, opt => opt.MapFrom(src => ""));
                config.CreateMap<CarParkingSiteViewModel, CarParkingSiteDetails>()
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdationDate, opt => opt.MapFrom(src => DateTime.Now));
                config.CreateMap<CarParkingSiteDetails, CarParkingSiteViewModel>();
            });
        }
    }
}