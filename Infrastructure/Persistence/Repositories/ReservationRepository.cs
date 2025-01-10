using Application.Common;
using Application.Interfaces;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ReservationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task AddAsync(Domain.Reservations.Reservation reservation, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Delete(Domain.Reservations.Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Domain.Reservations.ReservationId reservationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(List<Domain.Reservations.Reservation>, int totalCount)> GetAllPagedAsync(PaginationParameters paginationParameters, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Reservations.Reservation?> GetByIdAsync(Domain.Reservations.ReservationId reservationId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Reservations.Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
