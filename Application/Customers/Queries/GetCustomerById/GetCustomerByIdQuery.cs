using Application.Common;
using Application.Customers.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Customers.Queries.GetCustomerById
{
    public record GetCustomerByIdQuery : IRequest<ErrorOr<ApiResponse<CustomerResponseDTO>>>
    {
        public Guid Id { get; set; }

        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
