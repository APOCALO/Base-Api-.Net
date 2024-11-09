using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Customers
{
    public sealed class Customer : AggregateRoot
    {
        public Customer(CustomerId customerId, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool isActive)
        {
            CustomerId = customerId;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            IsActive = isActive;
        }

        // Private Constructor by EntityFramework better performance
        private Customer()
        {
            
        }

        public CustomerId CustomerId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string FullName => $"{Name} {LastName}";
        public string Email { get; private set; } = string.Empty;
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public bool IsActive { get; set; }
    }
}
