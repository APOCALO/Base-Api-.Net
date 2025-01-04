using Application.Common;
using ErrorOr;
using MediatR;

namespace Application.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand : IRequest<ErrorOr<ApiResponse<Unit>>>
    {
        public Guid Id { get; set; }

        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
