using Application.Common;
using Domain.Primitives;

namespace Application.Interfaces
{
    public interface IBaseRepository<T, TId>
        where T : class
        where TId : IValueObject
    {
        Task<(List<T>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken);
        Task<List<T>> FindByPropertyAsync(string propertyName, object value, CancellationToken cancellationToken);
        void Update(T entity);
        void Delete(T entity);
    }
}
