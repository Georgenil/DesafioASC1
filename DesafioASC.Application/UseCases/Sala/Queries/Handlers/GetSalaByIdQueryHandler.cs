using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Sala.Queries.Handlers
{
    public class GetSalaByIdQueryHandler : IQueryHandler<GetSalaByIdQuery, Domain.Entities.Sala?>
    {
        private readonly ISalaRepository _salaRepository;
        public GetSalaByIdQueryHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public async Task<Domain.Entities.Sala?> Handle(GetSalaByIdQuery request)
        {
            return await _salaRepository.GetByIdAsync(request.Id);
        }
    }
}