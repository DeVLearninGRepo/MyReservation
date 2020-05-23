using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;

namespace DeVLearninG.MyReservation.Domain
{
    public class MyReservationContext : DbContext
    {
        private string _connectionString;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<EventPaymentType> EventTypes { get; set; }

        public DbSet<ReservationReadResult> ReservationsReadResult { get; set; }

        public MyReservationContext()
        {
            _connectionString = @"Server=.\SQLEXPRESS14;Database=MyReservation;Trusted_Connection=True;";
        }

        public MyReservationContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MyReservationContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(this._connectionString,
               x => x.UseNetTopologySuite());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Event
            modelBuilder.Entity<Event>()
             .Property(x => x.Id)
             .HasDefaultValueSql("newid()");

            modelBuilder.Entity<Event>()
                .Property(x => x.IdEventPaymentType)
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
                .HasOne(x => x.EventPaymentType)
                .WithMany()
                .HasForeignKey(x => x.IdEventPaymentType)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
               .HasMany(x => x.Reservations)
               .WithOne(x => x.Event)
               .HasForeignKey(x => x.IdEvent);
            #endregion

            #region EventType
            modelBuilder.Entity<EventPaymentType>()
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

            #region EventPaymentType
            modelBuilder.Entity<EventPaymentType>().HasData(new EventPaymentType { Id = EventPaymentTypeEnum.FreeEvent, Name = nameof(EventPaymentTypeEnum.FreeEvent) });
            modelBuilder.Entity<EventPaymentType>().HasData(new EventPaymentType { Id = EventPaymentTypeEnum.PaidEvent, Name = nameof(EventPaymentTypeEnum.PaidEvent) });
            #endregion

            #region ReservationsReadResult
            modelBuilder.Entity<ReservationReadResult>()
                .HasNoKey()
                .ToView(null);
            #endregion

            RemovePluralizingTableNameConvention(modelBuilder);

            AddCreatedDatesAndUpdatedDate(modelBuilder);
        }

        private void RemovePluralizingTableNameConvention(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }

        private void AddCreatedDatesAndUpdatedDate(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes()
                .Where(x => !x.IsKeyless);

            foreach (var entity in allEntities)
            {
                entity.AddProperty("CreatedDate", typeof(DateTimeOffset))
                    .SetDefaultValueSql("sysdatetimeoffset()");
                entity.AddProperty("UpdatedDate", typeof(DateTimeOffset))
                    .SetDefaultValueSql("sysdatetimeoffset()");
            }
        }

    }

    public static class MigrationUtility
    {
        public enum MigrationType
        {
            Up,
            Down
        }

        public static string ReadSql(Type migrationType, MigrationType migrationTypeEnum)
        {
            var assembly = migrationType.Assembly;
            string resourceName = $"{migrationType.Namespace}.scripts.{migrationType.Name}.{migrationTypeEnum.ToString()}.sql";
            using (System.IO.Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException("Unable to find the SQL file from an embedded resource", resourceName);
                }
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
        }
    }

}
