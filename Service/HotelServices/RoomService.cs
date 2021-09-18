using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Entities.Bookings;
using Persistence.Contracts;
using Service.HotelServices.Contracts;

namespace Service.HotelServices
{
    class RoomService : BaseService<Room>, IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
