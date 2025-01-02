using Application.Common;
using Application.Extensions;
using Application.Interfaces;
using Domain.Customers;
using ErrorOr;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _dbContext.Customers.AddAsync(customer, cancellationToken);
        }

        public void Delete(Customer customer)
        {
            _dbContext.Customers.Remove(customer);
        }

        public async Task<bool> ExistsAsync(CustomerId customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.AnyAsync(c => c.Id == customerId, cancellationToken);
        }

        public async Task<(List<Customer>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken)
        {
            var totalCount = await _dbContext.Customers.CountAsync(cancellationToken);

            var customers = await _dbContext.Customers
                .AsQueryable()
                .Paginate(paginationParameters)
                .ToListAsync(cancellationToken);

            return (customers, totalCount);
        }

        public async Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken)
        {
            return await _dbContext.Customers.SingleOrDefaultAsync(c => c.Id == customerId, cancellationToken);
        }

        public void Update(Customer customer)
        {
            if (customer == null)
            {
                Error.Validation("CustomerRepository.Update", "customer cannot be null.");
                return;
            }

            // Marca la entidad como modificada en el contexto
            _dbContext.Customers.Attach(customer);
            _dbContext.Entry(customer).State = EntityState.Modified;
        }
    }
}
