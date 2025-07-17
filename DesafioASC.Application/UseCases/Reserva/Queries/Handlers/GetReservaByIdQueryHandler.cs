using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetReservaByIdQueryHandler : IQueryHandler<GetReservaByIdQuery, Domain.Entities.Reserva?>
    {
        private readonly IReservaRead _reservaRead;
        public GetReservaByIdQueryHandler(IReservaRead reservaRead)
        {
            _reservaRead = reservaRead;
        }
        public async Task<Domain.Entities.Reserva?> Handle(GetReservaByIdQuery request)
        {
            return await _reservaRead.GetReservaByIdAsync(request.Id);
        }
    }
}