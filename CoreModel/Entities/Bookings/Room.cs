using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel;
using CoreModel.Entities.Guests;

namespace CoreModel.Entities.Bookings
{
    public class Room : BaseEntity
    {
        public virtual string RoomNumber { get; set; }
        public virtual int Capacity { get; set; }
        public virtual decimal Rent { get; set; }
    }
}
