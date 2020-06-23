using DeVLearninG.MyReservation.Domain;
using DeVLearninG.MyReservation.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DeVLearninG.MyReservation.Test
{
    public class EventTests : IClassFixture<MyReservationContextFixture>
    {
        private MyReservationContextFixture _ctxFixture;

        public EventTests(MyReservationContextFixture ctxFixture)
        {
            _ctxFixture = ctxFixture;
        }

        [Fact]
        public void GetById()
        {

            EventRepository eventRepository = new EventRepository(_ctxFixture.Context);

            var event1 = eventRepository.GetById(new Guid("00000000-0000-0000-0000-000000000010"));

            //var eventInMemory = new List<Event>
            //{
            //    new Event() {Id = new Guid("00000000-0000-0000-0000-000000000001"), Date = DateTime.Now.AddDays(7), Title = "Primo evento live di DeVLearninG", Description = "Siamo felici di comunicare la prima live di DeVLearninG" },
            //    new Event() {Id = new Guid("00000000-0000-0000-0000-000000000002"), Date = DateTime.Now.AddDays(14), Title = "Secondo evento live di DeVLearninG", Description = "Siamo felici di comunicare la seconda live di DeVLearninG" },
            //    new Event() {Id = new Guid("00000000-0000-0000-0000-000000000003"), Date = DateTime.Now.AddDays(21), Title = "Terzo evento live di DeVLearninG", Description = "Siamo felici di comunicare la terza live di DeVLearninG" },
            //};




            //var context = new Mock<MyReservationContext>();
            //var dbSetMock = new Mock<DbSet<Event>>();
            //context.Setup(x => x.Set<Event>()).Returns(dbSetMock.Object);
            //dbSetMock.Setup(x => x.Add(It.IsAny<Event>())).Returns(eventInMemory);



                


            //var context.Setup(x => x.Set<TestClass>()).Returns(dbSetMock.Object);

            //var eventRepositoryMock = new Mock<IEventRepository>();

            //eventRepositoryMock.Setup(x => x.GetById(It.IsAny<Guid>()))
            //                   .Returns((Guid id) => eventInMemory.Find(x => x.Id == id));

            
            
            
            //var eventRepository = new EventRepository(eventRepositoryMock.Object)


            //var testObject = new TestClass();

            //var context = new Mock<DbContext>();
            //var dbSetMock = new Mock<DbSet<TestClass>>();
            //context.Setup(x => x.Set<TestClass>()).Returns(dbSetMock.Object);
            //dbSetMock.Setup(x => x.Add(It.IsAny<TestClass>())).Returns(testObject);

            //// Act
            //var repository = new Repository<TestClass>(context.Object);
            //repository.Add(testObject);

            ////Assert
            //context.Verify(x => x.Set<TestClass>());
            //dbSetMock.Verify(x => x.Add(It.Is<TestClass>(y => y == testObject)));

        }
    }
}
