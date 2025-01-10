using Application.Common;

namespace Application.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<(List<T>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
    }
}
