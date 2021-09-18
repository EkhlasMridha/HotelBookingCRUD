using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreModel.Entities.Bookings;

namespace Persistence.Configurations
{
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
        }
    }

    public class BookingDetailConfig : IEntityTypeConfiguration<BookingDetails>
    {
        public void Configure(EntityTypeBuilder<BookingDetails> builder)
        {
            builder.ToTable("BookingDetails");
        }
    }
    public class RoomConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
        }
    }
}
