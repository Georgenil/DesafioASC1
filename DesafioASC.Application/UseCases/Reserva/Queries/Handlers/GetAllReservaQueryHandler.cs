using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetAllReservaQueryHandler : IQueryHandler<GetAllReservaQuery, List<Domain.Entities.Reserva>?>
    {
        private readonly IReservaRepository _reservaRepository;
        public GetAllReservaQueryHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task<List<Domain.Entities.Reserva>?> Handle(GetAllReservaQuery request)
        {
            return await _reservaRepository.GetAllWithSalaAsync();
        }
    }
}
