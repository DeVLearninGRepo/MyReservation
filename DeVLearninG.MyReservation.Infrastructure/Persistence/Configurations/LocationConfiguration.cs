using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(255);

            builder.Property(x => x.Geoposition)
              .IsRequired();
        }
    }
}
