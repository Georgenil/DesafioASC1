using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Services;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetReservaByIdQueryHandler : IQueryHandler<GetReservaByIdQuery, Domain.Entities.Reserva?>
    {
        private readonly IReservaService _reservaService;
        public GetReservaByIdQueryHandler(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task<Domain.Entities.Reserva?> Handle(GetReservaByIdQuery request)
        {
            return await _reservaService.GetReservaByIdAsync(request.Id);
        }
    }
}