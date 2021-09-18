using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace CoreModel.Entities.Bookings
{
    public class BookingDetails : BaseEntity
    {
        public virtual DateTime BookedFrom { get; set; }
        public virtual DateTime LeaveAt { get; set; }
        public virtual long BookedBy { get; set; }
        public virtual string Comments { get; set; }
        public virtual StateEnum State { get; set; }
    }

    public enum StateEnum
    {
        [EnumMember,Description("Pending")]
        Pending=1,
        [EnumMember, Description("Booked")]
        Booked = 2
    }
}
