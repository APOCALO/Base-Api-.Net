using Application.Common;
using Application.Customers.DTOs;
using ErrorOr;
using MediatR;

namespace Application.Customers.Queries.GetAllCustomersPaged
{
    public record GetAllCustomersPagedAsyncQuery(PaginationParameters Pagination) : IRequest<ErrorOr<ApiResponse<IReadOnlyList<CustomerResponseDTO>>>>;
}
