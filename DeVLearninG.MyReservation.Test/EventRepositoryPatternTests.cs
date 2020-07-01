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
    public class EventRepositoryPatternTests : IClassFixture<MyReservationContextFixture>
    {
        private MyReservationContextFixture _ctxFixture;

        public EventRepositoryPatternTests(MyReservationContextFixture ctxFixture)
        {
            _ctxFixture = ctxFixture;
        }

        [Fact]
        public void GetById()
        {
            EventRepository eventRepository = new EventRepository(_ctxFixture.Context);

            var event1 = eventRepository.GetById(new Guid("00000000-0000-0000-0000-000000000010"));

        }
    }
}
