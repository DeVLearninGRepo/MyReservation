using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
