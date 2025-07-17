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

            var salaBd = _salaRepository.GetSalaAsync(s => s.Nome.Trim().ToLower() == request.Nome.Trim().ToLower());
            if (salaBd != null)
                throw new Exception("Sala já cadastrada");

            var sala = new Domain.Entities.Sala
            {
                Nome = request.Nome,
                CapacidadeMaxima = request.CapacidadeMaxima,
                DataHoraCriacao = DateTime.Now
            };

            await _salaRepository.CreateAsync(sala);
        }
    }
}
