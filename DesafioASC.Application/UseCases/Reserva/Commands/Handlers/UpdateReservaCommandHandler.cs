using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class UpdateReservaCommandHandler : ICommandHandler<UpdateReservaCommand>
    {
        private readonly IReservaWrite _reservaWrite;
        private readonly IReservaRead _reservaRead;
        public UpdateReservaCommandHandler(IReservaWrite reservaWrite,IReservaRead reservaRead)
        {
            _reservaWrite = reservaWrite;
            _reservaRead = reservaRead;
        }

        public async Task Handle(UpdateReservaCommand command)
        {
            if (command.DataHoraFim <= command.DataHoraCriacao)
                throw new ArgumentException("A data de fim deve ser posterior à data de criação.");

            var reservaBd = await _reservaRead.GetReservaByIdAsync(command.Id);

            if (reservaBd == null)
                throw new KeyNotFoundException("Reserva não encontrada.");


            if (reservaBd.Id != command.Id && reservaBd.SalaId == command.SalaId
                && !(command.DataHoraFim <= reservaBd.DataHoraCriacao || command.DataHoraCriacao >= reservaBd.DataHoraFim))
            {
                throw new InvalidOperationException("Já existe uma reserva para esta sala nesse período.");
            }
            if (reservaBd.SalaId == command.SalaId
                && command.QuantidadePessoa > reservaBd.Sala.CapacidadeMaxima)
            {
                throw new InvalidOperationException("Não é possível fazer uma reserva que ultrapasse a quantidade máxima de pessoas da Sala.");
            }

            reservaBd.DataHoraCriacao = command.DataHoraCriacao;
            reservaBd.DataHoraAtualizacao = DateTime.Now;
            reservaBd.DataHoraFim = command.DataHoraFim;
            reservaBd.SalaId = command.SalaId;
            reservaBd.QuantidadePessoa = command.QuantidadePessoa;

           
            await _reservaWrite.UpdateReservaAsync(reservaBd);
        }
    }
}
