using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Services;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class CreateReservaCommandHandler : ICommandHandler<CreateReservaCommand>
    {
        private readonly IReservaService _reservaService;

        public CreateReservaCommandHandler(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        public async Task Handle(CreateReservaCommand command)
        {
            var reserva = new Domain.Entities.Reserva
            {
                DataHoraCriacao = command.DataHoraCriacao,
                DataHoraFim = command.DataHoraFim,
                QuantidadePessoa = command.QuantidadePessoa,
                SalaId = command.SalaId,
            };

            await _reservaService.CreateReservaAsync(reserva);
        }
    }
}
