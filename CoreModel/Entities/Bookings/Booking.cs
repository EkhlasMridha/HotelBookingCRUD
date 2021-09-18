using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Entities.Bookings
{
    public class Booking : BaseEntity
    {
        public virtual long BookingId { get; set; }
        public virtual long RoomId { get; set; }
    }
}
