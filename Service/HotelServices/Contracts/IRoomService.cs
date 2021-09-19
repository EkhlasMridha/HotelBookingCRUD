using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Entities.Bookings;

namespace Service.HotelServices.Contracts
{
    public interface IRoomService : IBaseService<Room>
    {
        public Task<List<RoomStatusViewModel>> GetRoomDataList();
        public Task<List<RoomDetailViewModel>> RoomDetailView(long roomId);
    }
}
