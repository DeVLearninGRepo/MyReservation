using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid IdCustomer { get; set; }
        public Guid IdEvent { get; set; }
        public DateTime Date { get; set; }


        public Customer Customer { get; set; }
        public Event Event { get; set; }
    }
}
