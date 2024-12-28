using Domain.Customers;

namespace Application.Common.Interfaces
{
    public interface ICustomerRepository
    {
        Task<(IEnumerable<Customer>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken);
        Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(CustomerId customerId, CancellationToken cancellationToken);
        Task AddAsync(Customer customer, CancellationToken cancellationToken);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
