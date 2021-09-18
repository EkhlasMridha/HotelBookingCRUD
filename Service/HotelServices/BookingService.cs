using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using CoreModel.Entities.Bookings;
using Persistence.Contracts;

namespace Service.HotelServices
{
    class BookingService : BaseService<BookingDetails>, IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookingService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookingDetails> CreateBookingDataAsync(BookingDetails bookingDetails, long roomId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var result = await CreateAsync(bookingDetails);
                var booking = new Booking();
                booking.BookingId = result.Id;
                booking.RoomId = roomId;
                await _unitOfWork.Repository<Booking>().InsertAsync(booking);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitAsync();
                return result;
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackASync();
                var e = ex;
                throw;
            }
            
        }
    }
}
