using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class CreateReservaCommandHandler : ICommandHandler<CreateReservaCommand>
    {
        private readonly IReservaWrite _reservaWrite;
        private readonly IReservaRead _reservaRead;
        public CreateReservaCommandHandler(IReservaRead reservaRead, IReservaWrite reservaWrite)
        {
            _reservaRead = reservaRead;
            _reservaWrite = reservaWrite;
        }
        public async Task Handle(CreateReservaCommand command)
        {
            if (command.DataHoraFim <= command.DataHoraCriacao)
                throw new ArgumentException("A data de fim deve ser posterior à data de criação.");

            var reservas = _reservaRead.GetAllReservaWithSalaAsync().Result;

            foreach (var res in reservas)
            {
                if (res.SalaId == command.SalaId
                    && !(command.DataHoraFim <= res.DataHoraCriacao || command.DataHoraCriacao >= res.DataHoraFim))
                {
                    throw new InvalidOperationException("Já existe uma reserva para esta sala nesse período.");
                }
                if (res.SalaId == command.SalaId
                    && command.QuantidadePessoa > res.Sala.CapacidadeMaxima)
                {
                    throw new InvalidOperationException("Não é possível fazer uma reserva que ultrapasse a qualtidade máxima de pessoas da Sala.");
                }
            }

            var reserva = new Domain.Entities.Reserva
            {
                DataHoraCriacao = command.DataHoraCriacao,
                DataHoraFim = command.DataHoraFim,
                SalaId = command.SalaId,
                QuantidadePessoa = command.QuantidadePessoa,
            };
            await _reservaWrite.CreateReservaAsync(reserva);
        }
    }
}
