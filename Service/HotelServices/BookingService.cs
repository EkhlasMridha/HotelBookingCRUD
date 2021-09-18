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
    }
}
