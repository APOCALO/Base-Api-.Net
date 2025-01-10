using Application.Common;
using Application.Interfaces;
using Domain.Customers;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

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

        public Task<(List<Customer>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken)
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
