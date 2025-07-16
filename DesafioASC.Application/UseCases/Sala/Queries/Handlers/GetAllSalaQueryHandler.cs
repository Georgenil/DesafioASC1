using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Sala.Queries.Handlers
{
    public class GetAllSalaQueryHandler : IQueryHandler<GetAllSalaQuery, List<Domain.Entities.Sala>?>
    {
        private readonly ISalaRepository _salaRepository;
        public GetAllSalaQueryHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public async Task<List<Domain.Entities.Sala>?> Handle(GetAllSalaQuery request)
        {
            return await _salaRepository.GetAllAsync();
        }
    }
}