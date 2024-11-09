using Application.Common;
using AutoMapper;
using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using Infrastructure.Persistence.Interfaces;
using MediatR;
using System.Diagnostics;

namespace Application.Customers.Commands.CreateCustomer
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<ApiResponse<Unit>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<ErrorOr<ApiResponse<Unit>>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var stopwatch = Stopwatch.StartNew();

            if (Address.Create(request.Country, request.Department, request.City, request.Line, request.PostalCode) is not Address address)
            {
                return Error.Validation("CreateCustomer.Address", "Address has not valid format.");
            }

            var customer = _mapper.Map<Customer>(request);

            await _customerRepository.AddAsync(customer, cancellationToken).ConfigureAwait(false);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            stopwatch.Stop();

            var response = new ApiResponse<Unit>(Unit.Value, true)
            {
                ResponseTime = stopwatch.Elapsed.TotalMilliseconds
            };

            return response;
        }
    }
}
