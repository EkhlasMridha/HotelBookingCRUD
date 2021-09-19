using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Entities.Bookings
{
    public class RoomDetailViewModel
    {
        public DateTime BookedFrom { get; set; }
        public DateTime LeaveAt { get; set; }
        public decimal PaidAmount { get; set; }
        public string Comments { get; set; }
        public decimal RoomRent { get; set; }
        public string BookedBy { get; set; }
    }
}
