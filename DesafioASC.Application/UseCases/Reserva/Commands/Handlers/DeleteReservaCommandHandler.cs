using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class DeleteReservaCommandHandler : ICommandHandler<DeleteReservaCommand>
    {
        private readonly IReservaWrite _reservaWrite;
        private readonly IReservaRead _reservaRead;
        public DeleteReservaCommandHandler(IReservaWrite reservaWrite,
            IReservaRead reservaRead)
        {
            _reservaWrite = reservaWrite;
            _reservaRead = reservaRead;
        }
        public async Task Handle(DeleteReservaCommand command)
        {
            var reserva = await _reservaRead.GetReservaByIdAsync(command.Id);
            if (reserva == null)
            {
                throw new KeyNotFoundException("Reserva não encontrada.");
            }
            await _reservaWrite.DeleteReservaAsync(reserva.Id);
        }
    }
}
