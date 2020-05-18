using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public enum EventTypeEnum
    {
        PaidEvent = 1,
        FreeEvent = 2
    }

    public class EventType
    {
        public EventTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
