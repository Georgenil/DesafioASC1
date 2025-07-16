using DesafioASC.Domain.Interfaces;

namespace DesafioASC.Application.UseCases.Reserva.Commands.Handlers
{
    public class CreateReservaCommandHandler : ICommandHandler<CreateReservaCommand>
    {
        private readonly IReservaRepository _reservaRepository;
        public CreateReservaCommandHandler(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }
        public async Task Handle(CreateReservaCommand command)
        {
            if (command.DataHoraFim <= command.DataHoraCriacao)
                throw new ArgumentException("A data de fim deve ser posterior à data de criação.");

            var reservas = _reservaRepository.GetAllWithSalaAsync().Result;

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
                    throw new InvalidOperationException("Quantidade de pessoas ultrapassa a capacidade da sala");
                }
            }

            bool conflito = reservas.Any(r =>
                r.SalaId == command.SalaId &&
                !(command.DataHoraFim <= r.DataHoraCriacao || command.DataHoraCriacao >= r.DataHoraFim));

            if (conflito)
            {
                throw new InvalidOperationException("Já existe uma reserva para esta sala nesse período.");
            }

            var reserva = new Domain.Entities.Reserva
            {
                DataHoraCriacao = command.DataHoraCriacao,
                DataHoraFim = command.DataHoraFim,
                SalaId = command.SalaId,
            };
            await _reservaRepository.CreateAsync(reserva);
        }
    }
}
