using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Services;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetAllReservaQueryHandler : IQueryHandler<GetAllReservaQuery, List<Domain.Entities.Reserva>?>
    {
        private readonly IReservaService _reservaService;
        public GetAllReservaQueryHandler(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task<List<Domain.Entities.Reserva>?> Handle(GetAllReservaQuery request)
        {
            return await _reservaService.GetAllReservaWithSalaAsync();
        }
    }
}
