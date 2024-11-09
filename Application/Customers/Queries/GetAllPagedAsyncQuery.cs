using Application.Common;
using Application.Customers.DTOs;
using ErrorOr;
using Infrastructure.Common;
using MediatR;

namespace Application.Customers.Queries
{
    public record GetAllPagedAsyncQuery(PaginationParameters Pagination) : IRequest<ErrorOr<ApiResponse<IReadOnlyList<CustomerResponseDTO>>>>;
}
