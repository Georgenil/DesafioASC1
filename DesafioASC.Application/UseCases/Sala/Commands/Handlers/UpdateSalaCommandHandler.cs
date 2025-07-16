using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Sala.Commands.Handlers
{
    public class UpdateSalaCommandHandler : ICommandHandler<UpdateSalaCommand>
    {
        private readonly ISalaRepository _salaRepository;
        public UpdateSalaCommandHandler(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }
        public async Task Handle(UpdateSalaCommand request)
        {
            var salaBd = await _salaRepository.GetByIdAsync(request.Id);
            if (salaBd == null)
                throw new Exception("Sala não foi cadastrada");

            salaBd.Nome = request.Nome;
            salaBd.CapacidadeMaxima = request.CapacidadeMaxima;
            salaBd.DataHoraAtualizacao = DateTime.Now;

            await _salaRepository.UpdateAsync(salaBd);
        }
    }
}
