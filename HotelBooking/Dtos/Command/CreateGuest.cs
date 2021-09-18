using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Dtos.Command
{
    public class CreateGuest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string ContactNumber { get; set; }
    }
}
