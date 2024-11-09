using Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Event { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
