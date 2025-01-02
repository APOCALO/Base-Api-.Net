using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Reservations
{
    public sealed class Reservation : AggregateRoot
    {
        public Reservation(ReservationId reservationId, 
            DateTime reservationDate, 
            ReservationStatusEnum status, 
            CustomerId customerId, 
            string customerName, 
            string customerLastName, 
            string customerEmail, 
            PhoneNumber customerPhone, 
            DateTime serviceStartDate, 
            DateTime serviceEndDate)
        {
            ReservationId = reservationId;
            ReservationDate = reservationDate;
            Status = status;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            ServiceStartDate = serviceStartDate;
            ServiceEndDate = serviceEndDate;
        }

        // Constructor Privado para qué EntityFramework tenga mejor rendimiento
        public Reservation()
        {

        }

        public ReservationId ReservationId { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public ReservationStatusEnum Status { get; private set; }

        // Cliente
        public CustomerId CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public string CustomerLastName { get; private set; }
        public string CustomerFullName => $"{CustomerName} {CustomerLastName}";
        public string CustomerEmail { get; private set; }
        public PhoneNumber CustomerPhone { get; private set; }

        // Fechas del servicio
        public DateTime ServiceStartDate { get; private set; }
        public DateTime ServiceEndDate { get; private set; }
    }
}
