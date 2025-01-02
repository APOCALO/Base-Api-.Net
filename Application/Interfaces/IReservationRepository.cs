using Application.Common;
using Domain.Reservations;

namespace Application.Interfaces
{
    public interface IReservationRepository
    {
        Task<(List<Reservation>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken);
        Task<Reservation?> GetByIdAsync(ReservationId reservationId, CancellationToken cancellationToken);
        Task<bool> ExistsAsync(ReservationId reservationId, CancellationToken cancellationToken);
        Task AddAsync(Reservation reservation, CancellationToken cancellationToken);
        void Update(Reservation reservation);
        void Delete(Reservation reservation);
    }
}
