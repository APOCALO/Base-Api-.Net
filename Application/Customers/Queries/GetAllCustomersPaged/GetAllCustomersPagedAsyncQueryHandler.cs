using Application.Common;
using Application.Common.Interfaces;
using Application.Customers.DTOs;
using AutoMapper;
using ErrorOr;
using MediatR;
using System.Diagnostics;

namespace Application.Customers.Queries.GetAllCustomersPaged
{
    internal sealed class GetAllCustomersPagedAsyncQueryHandler : IRequestHandler<GetAllCustomersPagedAsyncQuery, ErrorOr<ApiResponse<IReadOnlyList<CustomerResponseDTO>>>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersPagedAsyncQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<ErrorOr<ApiResponse<IReadOnlyList<CustomerResponseDTO>>>> Handle(GetAllCustomersPagedAsyncQuery request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            var (customers, totalCount) = await _customerRepository.GetAllPagedAsync(request.Pagination, cancellationToken);

            var customerDTOs = _mapper.Map<IReadOnlyList<CustomerResponseDTO>>(customers);

            var paginationMetadata = new PaginationMetadata
            {
                TotalCount = totalCount,
                PageSize = request.Pagination.PageSize,
                PageNumber = request.Pagination.PageNumber
            };

            stopwatch.Stop();

            var response = new ApiResponse<IReadOnlyList<CustomerResponseDTO>>(customerDTOs, true, paginationMetadata)
            {
                ResponseTime = stopwatch.Elapsed.TotalMilliseconds
            };

            return response;
        }
    }
}
