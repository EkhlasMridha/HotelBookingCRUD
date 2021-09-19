using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Entities.Bookings;

namespace Service.HotelServices.Contracts
{
    public interface IBookingService : IBaseService<BookingDetails>
    {
        public Task<BookingDetails> CreateBookingDataAsync(BookingDetails bookingDetails, long roomId);
        public Task<List<BookingViewModel>> GetAllBookings();
    }
}
