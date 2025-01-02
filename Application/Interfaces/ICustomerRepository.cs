using Application.Common;
using Domain.Customers;

namespace Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<(List<Customer>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken);
        Task<Customer?> GetByIdAsync(CustomerId customerId, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(CustomerId customerId, CancellationToken cancellationToken);
        Task AddAsync(Customer customer, CancellationToken cancellationToken);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
