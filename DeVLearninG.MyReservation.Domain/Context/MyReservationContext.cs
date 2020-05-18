using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeVLearninG.MyReservation.Domain
{
    public class MyReservationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS14;Database=MyReservation;Trusted_Connection=True;",
                x => x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Event
            modelBuilder.Entity<Event>()
             .Property(x => x.Id)
             .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Event>()
                .Property(x => x.IdEventType)
                .IsRequired();

            modelBuilder.Entity<Event>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Event>()
              .Property(x => x.Title)
              .IsRequired()
              .HasMaxLength(255);

            modelBuilder.Entity<Event>()
              .Property(x => x.Description)
              .IsRequired()
              .HasMaxLength(4000);


            modelBuilder.Entity<Event>()
                .HasOne(x => x.Location)
                .WithMany(x => x.Events)
                .HasForeignKey(x => x.IdLocation);

            modelBuilder.Entity<Event>()
                .HasOne(x => x.EventType)
                .WithMany()
                .HasForeignKey(x => x.IdEventType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
               .HasMany(x => x.Reservations)
               .WithOne(x => x.Event)
               .HasForeignKey(x => x.IdEvent);
            #endregion

            #region EventType
            modelBuilder.Entity<EventType>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
            #endregion

            #region Customer
            modelBuilder.Entity<Customer>()
                .Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Customer>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Customer>()
               .Property(x => x.Surname)
               .IsRequired()
               .HasMaxLength(255);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.IdCustomer);
            #endregion

            #region Location
            modelBuilder.Entity<Location>()
                .Property(x => x.Id)
                .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Location>()
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(255);

            modelBuilder.Entity<Location>()
              .Property(x => x.Geoposition)
              .IsRequired();
            #endregion

            #region Reservation
            modelBuilder.Entity<Reservation>()
                .Property(x => x.Id)
                .HasDefaultValueSql("newid()");
            #endregion

            modelBuilder.Entity<EventType>().HasData(new EventType { Id = EventTypeEnum.FreeEvent, Name = nameof(EventTypeEnum.FreeEvent) });
            modelBuilder.Entity<EventType>().HasData(new EventType { Id = EventTypeEnum.PaidEvent, Name = nameof(EventTypeEnum.PaidEvent) });

            RemovePluralizingTableNameConvention(modelBuilder);
        }

        public void RemovePluralizingTableNameConvention(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
