using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DeVLearninG.MyReservation.Infrastructure.Persistence
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
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.UseNetTopologySuite());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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
            //Debugger.Launch();

            var allEntities = modelBuilder.Model.GetEntityTypes()
                .Where(x => { return !ExcludeShadowProperty(x); });

            foreach (var entity in allEntities)
            {
                entity.AddProperty("CreatedDate", typeof(DateTimeOffset))
                    .SetDefaultValueSql("sysdatetimeoffset()");
                entity.AddProperty("UpdatedDate", typeof(DateTimeOffset))
                    .SetDefaultValueSql("sysdatetimeoffset()");
            }
        }

        private bool ExcludeShadowProperty(IMutableEntityType mutableEntityType)
        {
            if (mutableEntityType.IsKeyless) return true;

            var attribute = Attribute.GetCustomAttribute(mutableEntityType.ClrType, typeof(OmitShadowPropertyAttribute));

            return attribute != null;
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
