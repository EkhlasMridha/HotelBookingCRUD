using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModel.Entities.Settings
{
    public class BookingSetting : BaseEntity
    {
        public virtual decimal Discount { get; set; }
        public virtual decimal TaxPercentage { get; set; }
    }
}
