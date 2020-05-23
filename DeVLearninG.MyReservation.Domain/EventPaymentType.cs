using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public enum EventPaymentTypeEnum
    {
        PaidEvent = 1,
        FreeEvent = 2
    }

    public class EventPaymentType
    {
        public EventPaymentTypeEnum Id { get; set; }
        public string Name { get; set; }
    }
}
