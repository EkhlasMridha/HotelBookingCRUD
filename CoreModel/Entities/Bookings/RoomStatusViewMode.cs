using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Entities.Bookings
{
    public class RoomStatusViewModel
    {
        public long Id { get; set; }
        public virtual string RoomNumber { get; set; }
        public virtual int Capacity { get; set; }
        public virtual decimal Rent { get; set; }
        public virtual long OnGoingBooking{ get; set; }
        public virtual long ClosedBooking { get; set; }
    }
}
