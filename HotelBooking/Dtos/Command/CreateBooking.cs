using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Dtos.Command
{
    public class CreateBooking
    {
        public DateTime BookedFrom { get; set; }
        public DateTime LeaveAt { get; set; }
        public long BookedBy { get; set; }
        public long RoomId { get; set; }
        public string Comments { get; set; }
    }
}
