using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Configurations
{
    public class ReservationReadResultConfiguration : IEntityTypeConfiguration<ReservationReadResult>
    {
        public void Configure(EntityTypeBuilder<ReservationReadResult> builder)
        {
            builder.HasNoKey()
                .ToView(null);
        }
    }
}
