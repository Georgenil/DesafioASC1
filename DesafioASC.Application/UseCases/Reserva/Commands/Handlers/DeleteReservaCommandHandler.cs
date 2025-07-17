using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Services;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class DeleteReservaCommandHandler : ICommandHandler<DeleteReservaCommand>
    {
        private readonly IReservaService _reservaService;
        public DeleteReservaCommandHandler(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task Handle(DeleteReservaCommand command)
        {
            await _reservaService.DeleteReservaAsync(command.Id);
        }
    }
}
