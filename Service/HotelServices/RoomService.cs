using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Entities.Bookings;
using Persistence.Contracts;
using Service.HotelServices.Contracts;
using Persistence;
using System.Data.SqlClient;
using Service.Extensions;

namespace Service.HotelServices
{
    class RoomService : BaseService<Room>, IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork):base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RoomStatusViewModel>> GetRoomDataList()
        {
            string spName = "sp_get_roominfolist";
            List<SqlParameter> parameters = new List<SqlParameter>();
            var data = await _unitOfWork.Repository<BookingDetails>().ExecuteSqlDataReader(spName, parameters);

            var result = data.ConvertToList<RoomStatusViewModel>();
            return result;
        }
    }
}
