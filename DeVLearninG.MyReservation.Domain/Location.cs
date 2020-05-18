using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Point Geoposition { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
