using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public class ReservationReadResult
    {
        public Guid IdReservation { get; set; }
        public DateTimeOffset ReservationDate { get; set; }
        public string EventTitle { get; set; }
        public string LocationName { get; set; }
        public Point LocationPosition { get; set; }
    }
}
