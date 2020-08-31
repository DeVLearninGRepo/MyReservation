using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Configurations
{
    public class EventPaymentTypeConfiguration : IEntityTypeConfiguration<EventPaymentType>
    {
        public void Configure(EntityTypeBuilder<EventPaymentType> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasData(new EventPaymentType { Id = EventPaymentTypeEnum.FreeEvent, Name = nameof(EventPaymentTypeEnum.FreeEvent) });
            builder.HasData(new EventPaymentType { Id = EventPaymentTypeEnum.PaidEvent, Name = nameof(EventPaymentTypeEnum.PaidEvent) });
        }
    }
}
