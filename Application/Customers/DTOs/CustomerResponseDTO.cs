using Domain.Customers;
using Domain.ValueObjects;

namespace Application.Customers.DTOs
{
    public record CustomerResponseDTO
    {
        public CustomerResponseDTO(CustomerId customerId, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool isActive)
        {
            CustomerId = customerId;
            Name = name;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            IsActive = isActive;
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

    public record AddressResponseDTO(string Country, string Department, string City, string Line, string PostalCode);

    public record PhoneNumberResponseDTO(string value, string countryCode);
}
