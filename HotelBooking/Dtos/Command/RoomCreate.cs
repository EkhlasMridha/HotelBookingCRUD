using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Dtos.Command
{
    public class RoomCreate
    {
        public string RoomNumber { get; set; }
        public int Capacity { get; set; }
        public decimal Rent { get; set; }

    }
}
