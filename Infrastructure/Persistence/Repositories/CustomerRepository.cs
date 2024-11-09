using Domain.Customers;
using Infrastructure.Common;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        public Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(CustomerId customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(IEnumerable<Customer>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
