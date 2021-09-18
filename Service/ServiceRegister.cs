using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.HotelServices.Contracts;
using Service.HotelServices;

namespace Service
{
    public static class ServiceRegister
    {
        public static void Addservices(this IServiceCollection services)
        {
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IGuestService, GuestService>();
        }
    }
}
