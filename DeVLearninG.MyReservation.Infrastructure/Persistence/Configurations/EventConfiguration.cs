using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(x => x.IdEventPaymentType)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(4000);


            builder.HasOne(x => x.Location)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.IdLocation);

            builder.HasOne(x => x.EventPaymentType)
                .WithMany()
                .HasForeignKey(x => x.IdEventPaymentType)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Reservations)
               .WithOne(x => x.Event)
               .HasForeignKey(x => x.IdEvent);
        }
    }
}
