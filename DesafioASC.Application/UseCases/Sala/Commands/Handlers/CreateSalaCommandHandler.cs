using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Sala.Commands.Handlers
{
    public class CreateSalaCommandHandler : ICommandHandler<CreateSalaCommand>
    {
        private readonly ISalaRepository _salaRepository;
        public CreateSalaCommandHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public async Task Handle(CreateSalaCommand request)
        {
            if (string.IsNullOrEmpty(request.Nome))
                throw new Exception("Sala precisa ter um nome");

            var sala = new Domain.Entities.Sala
            {
                Nome = request.Nome.Trim(),
                CapacidadeMaxima = request.CapacidadeMaxima
            };

            await _salaRepository.CreateSalaAsync(sala);
        }
    }
}
