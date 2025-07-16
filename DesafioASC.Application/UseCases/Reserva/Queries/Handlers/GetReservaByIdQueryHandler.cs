using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetReservaByIdQueryHandler : IQueryHandler<GetReservaByIdQuery, Domain.Entities.Reserva?>
    {
        private readonly IReservaRepository _reservaRepository;
        public GetReservaByIdQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task<Domain.Entities.Reserva?> Handle(GetReservaByIdQuery request)
        {
            return await _reservaRepository.GetByIdAsync(request.Id);
        }
    }
}