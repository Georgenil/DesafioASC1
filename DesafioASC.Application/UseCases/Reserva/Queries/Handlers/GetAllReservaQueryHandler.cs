using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Queries.Handlers
{
    public class GetAllReservaQueryHandler : IQueryHandler<GetAllReservaQuery, List<Domain.Entities.Reserva>?>
    {
        private readonly IReservaRead _reservaRead;
        public GetAllReservaQueryHandler(IReservaRead reservaRead)
        {
            _reservaRead = reservaRead;
        }
        public async Task<List<Domain.Entities.Reserva>?> Handle(GetAllReservaQuery request)
        {
            return await _reservaRead.GetAllReservaWithSalaAsync();
        }
    }
}
