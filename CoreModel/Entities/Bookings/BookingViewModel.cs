using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Entities.Bookings
{
    public class BookingViewModel
    {
        public long Id { get; set; }
        public virtual DateTime BookedFrom { get; set; }
        public virtual DateTime LeaveAt { get; set; }
        public virtual long BookedBy { get; set; }
        public decimal PaidAmount { get; set; }
        public virtual string Comments { get; set; }
        public string GuestName { get; set; }
        public long GuestId { get; set; }
        public string RoomNumber { get; set; }
        public long RoomId { get; set; }
    }
}
