using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Services;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class UpdateReservaCommandHandler : ICommandHandler<UpdateReservaCommand>
    {
        private readonly IReservaService _reservaService;
        public UpdateReservaCommandHandler(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        public async Task Handle(UpdateReservaCommand command)
        {
            var reserva = new Domain.Entities.Reserva
            {
                Id = command.Id,
                DataHoraCriacao = command.DataHoraCriacao,
                DataHoraFim = command.DataHoraFim,
                QuantidadePessoa = command.QuantidadePessoa,
                SalaId = command.SalaId,
            };

            await _reservaService.UpdateReservaAsync(reserva);
        }
    }
}
