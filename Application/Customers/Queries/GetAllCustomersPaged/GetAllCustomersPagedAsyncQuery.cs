using Application.Common;
using Application.Customers.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Customers.Queries.GetAllCustomersPaged
{
    public record GetAllCustomersPagedAsyncQuery : IRequest<ErrorOr<ApiResponse<IEnumerable<CustomerResponseDTO>>>>
    {
        public PaginationParameters Pagination { get; set; }

        public GetAllCustomersPagedAsyncQuery(PaginationParameters pagination)
        {
            Pagination = pagination;
        }
    }
}
