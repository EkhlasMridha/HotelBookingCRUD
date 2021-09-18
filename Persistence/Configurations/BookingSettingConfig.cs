using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModel.Entities.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class BookingSettingConfig : IEntityTypeConfiguration<BookingSetting>
    {
        public void Configure(EntityTypeBuilder<BookingSetting> builder)
        {
            builder.ToTable("BookingSettings");
        }
    }
}
