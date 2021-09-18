using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreModel.Entities.Bookings;
using CoreModel.Entities.Guests;
using CoreModel.Entities.Settings;
using HotelBooking.Dtos.Command;

namespace HotelBooking
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoomCreate, Room>();
        }
    }
}
