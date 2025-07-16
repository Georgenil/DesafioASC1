using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Sala.Commands.Handlers
{
    public class DeleteSalaCommandHandler : ICommandHandler<DeleteSalaCommand>
    {
        private readonly ISalaRepository _salaRepository;
        public DeleteSalaCommandHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public async Task Handle(DeleteSalaCommand request)
        {
            await _salaRepository.DeleteAsync(request.Id);
        }
    }
}
