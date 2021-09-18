using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Dtos.Command
{
    public class SettingCommand
    {
        public long Id { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercentage { get; set; }
    }
}
