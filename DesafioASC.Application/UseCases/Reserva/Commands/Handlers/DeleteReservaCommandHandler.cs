using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class DeleteReservaCommandHandler : ICommandHandler<DeleteReservaCommand>
    {
        private readonly IReservaRepository _reservaRepository;
        public DeleteReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task Handle(DeleteReservaCommand command)
        {
            var reserva = await _reservaRepository.GetByIdAsync(command.Id);
            if (reserva == null)
            {
                throw new KeyNotFoundException("Reserva não encontrada.");
            }
            await _reservaRepository.DeleteAsync(reserva.Id);
        }
    }
}
