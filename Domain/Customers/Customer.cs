using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers
{
    public sealed class Customer : AggregateRoot
    {
        public Customer(CustomerId customerId, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool isActive)
        {
            Id = customerId;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            IsActive = isActive;
        }

        // Constructor Privado para qué EntityFramework tenga mejor rendimiento
        private Customer()
        {
            
        }

        public CustomerId Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{Name} {LastName}";
        public string Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public bool IsActive { get; private set; } = true;
    }
}
