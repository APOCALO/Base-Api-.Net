using Application.Common;
using Domain.Customers;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Commands
{
    public record CreateCustomerCommand : IRequest<ErrorOr<ApiResponse<Unit>>>
    {
        public CreateCustomerCommand(CustomerId customerId, string name, string lastName, string email, PhoneNumber phoneNumber, Address address, bool isActive)
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
        public string Country { get; init; } = string.Empty;
        public string Department { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string PostalCode { get; init; } = string.Empty;
        public string Line { get; init; } = string.Empty;
    }
}
