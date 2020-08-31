using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Surname)
               .IsRequired()
               .HasMaxLength(255);

            builder.HasMany(x => x.Reservations)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.IdCustomer);
        }
    }
}
