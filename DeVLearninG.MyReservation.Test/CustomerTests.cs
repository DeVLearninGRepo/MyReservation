using DeVLearninG.MyReservation.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace DeVLearninG.MyReservation.Test
{
    public class CustomerTests : IClassFixture<MyReservationContextFixture>
    {
        private MyReservationContextFixture _ctxFixture;

        public CustomerTests(MyReservationContextFixture ctxFixture)
        {
            _ctxFixture = ctxFixture;
        }

        [Fact]
        public void CustomerCanCreate()
        {
            _ctxFixture.Context.Customers.Add(new Customer() { Id = new Guid("6ED5B456-1313-4166-9606-0892D08F4E74"), Name = "NameTest1", Surname = "SurnameTest1" });

            int affectedRows = _ctxFixture.Context.SaveChanges();

            Assert.Equal(1, affectedRows);
        }

        [Fact]
        public void CustomerCanRead()
        {
            var customer = (from c in _ctxFixture.Context.Customers
                         where c.Id == new Guid("00000000-0000-0000-0000-000000000100")
                         select c);

            Assert.NotNull(customer);
        }

        [Fact]
        public void CustomerCanUpdateConnected()
        {
            var customer = (from c in _ctxFixture.Context.Customers
                            where c.Id == new Guid("00000000-0000-0000-0000-000000000100")
                            select c).FirstOrDefault();

            customer.Name = "NameTestConnected100";
            customer.Surname = "SurnameTestConnected100";

            int affectedRows = _ctxFixture.Context.SaveChanges();

            Assert.Equal(1, affectedRows);
        }

        [Fact]
        public void CustomerCanUpdateDisconnected()
        {
            var customer = (from c in _ctxFixture.Context.Customers
                            where c.Id == new Guid("00000000-0000-0000-0000-000000000100")
                            select c).FirstOrDefault();

            _ctxFixture.Context.Entry<Customer>(customer).State = EntityState.Detached;

            var disconnectedCustomer = new Customer();
            disconnectedCustomer.Id = new Guid("00000000-0000-0000-0000-000000000100");
            disconnectedCustomer.Name = "NameTestDisconnected100";
            disconnectedCustomer.Surname = "SurnameTestDisconnected100";
            _ctxFixture.Context.Customers.Update(disconnectedCustomer);

            int affectedRows = _ctxFixture.Context.SaveChanges();

            Assert.Equal(1, affectedRows);
        }

        //[Fact]
        //public async void Customer_Stored()
        //{
        //    SqlParameter sqlParameter = new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier);
        //    sqlParameter.Value = new Guid("3204091B-1D29-4FC2-8225-15B53CDDAC8E");

        //    var requests = await _ctxFixture.Context.ReservationsReadResult.FromSqlRaw<ReservationReadResult>("exec Reservation_Read @Id", sqlParameter).ToListAsync();
        //}
    }
}
