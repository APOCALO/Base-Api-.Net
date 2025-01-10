using Application.Common;
using MediatR;

namespace Application.Reservations.Commands.CreateReservation
{
    public record CreateReservationCommand : BaseResponse<Unit>
    {

    }
}
