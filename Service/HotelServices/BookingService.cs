using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.HotelServices.Contracts;
using CoreModel.Entities.Bookings;
using Persistence.Contracts;
using System.Data.SqlClient;
using Service.Extensions;

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

        public async Task<List<BookingViewModel>> GetAllBookings()
        {
            try
            {
                string spName = "sp_get_bookingdetails";
                List<SqlParameter> parameters = new List<SqlParameter>();
                var data = await _unitOfWork.Repository<BookingDetails>().ExecuteSqlDataReader(spName, parameters);
                var result = data.ConvertToList<BookingViewModel>();
                return result;
            }catch(Exception e)
            {
                var ex = e;
                throw;
            }
        }
    }
}
