﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid IdLocation { get; set; }
        public EventTypeEnum IdEventType { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public EventType EventType { get; set; }
        public Location Location { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
