using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;

namespace DesafioASC.Persistence.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaWrite _reservaWrite;
        private readonly IReservaRead _reservaRead;
        private readonly ILogger<ReservaService> _logger;
        private readonly ResiliencePipeline _pipeline;

        public ReservaService(IReservaWrite reservaWrite,
            IReservaRead reservaRead,
            ILogger<ReservaService> logger,
            ResiliencePipeline pipeline)
        {
            _reservaWrite = reservaWrite;
            _reservaRead = reservaRead;
            _logger = logger;
            _pipeline = pipeline;
        }

        public async Task<List<Reserva>> GetAllReservaAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Reserva>> GetAllReservaWithSalaAsync()
        {
            var resultado = await _pipeline.ExecuteAsync(async _ =>
            {
                _logger.LogInformation("Buscando reservas...");
                return await _reservaRead.GetAllReservaWithSalaAsync();
            });

            return resultado;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _reservaRead.GetReservaByIdAsync(id);
        }

        public Task<Reserva> GetReservaByIdWithAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Reserva> CreateReservaAsync(Reserva entity)
        {
            ValidadeCreateReservaAsync(entity, _reservaRead);
            var resultado = await _pipeline.ExecuteAsync(async _ =>
            {
                _logger.LogInformation("Registrando reservas...");
               return await _reservaWrite.CreateReservaAsync(entity);
            });
            return resultado;
        }

        public async Task<Reserva> UpdateReservaAsync(Reserva entity)
        {
            var reservaBd = _reservaRead.GetReservaByIdAsync(entity.Id).Result;
            ValidateUpdateReservaAsync(entity, reservaBd);

            reservaBd.DataHoraCriacao = entity.DataHoraCriacao;
            reservaBd.DataHoraAtualizacao = DateTime.Now;
            reservaBd.DataHoraFim = entity.DataHoraFim;
            reservaBd.SalaId = entity.SalaId;
            reservaBd.QuantidadePessoa = entity.QuantidadePessoa;

            return await _reservaWrite.UpdateReservaAsync(reservaBd);
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var reserva = await _reservaRead.GetReservaByIdAsync(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException("Reserva não encontrada.");
            }
            return await _reservaWrite.DeleteReservaAsync(reserva.Id);
        }

        private void ValidateUpdateReservaAsync(Reserva reserva, Reserva reservaBd)
        {
            if (reserva.DataHoraFim <= reserva.DataHoraCriacao)
                throw new ArgumentException("A data de fim deve ser posterior à data de criação.");

            if (reservaBd == null)
                throw new KeyNotFoundException("Reserva não encontrada.");

            if (reservaBd.Id != reserva.Id && reservaBd.SalaId == reserva.SalaId
                && !(reserva.DataHoraFim <= reservaBd.DataHoraCriacao || reserva.DataHoraCriacao >= reservaBd.DataHoraFim))
            {
                throw new InvalidOperationException("Já existe uma reserva para esta sala nesse período.");
            }
            if (reservaBd.SalaId == reserva.SalaId
                && reserva.QuantidadePessoa > reservaBd.Sala.CapacidadeMaxima)
            {
                throw new InvalidOperationException("Não é possível fazer uma reserva que ultrapasse a quantidade máxima de pessoas da Sala.");
            }
        }

        private void ValidadeCreateReservaAsync(Reserva reserva, IReservaRead _reservaRead)
        {
            if (reserva.DataHoraFim <= reserva.DataHoraCriacao)
                throw new ArgumentException("A data de fim deve ser posterior à data de criação.");
            var reservas = _reservaRead.GetAllReservaWithSalaAsync().Result;
            foreach (var res in reservas)
            {
                if (res.SalaId == reserva.SalaId
                    && !(reserva.DataHoraFim <= res.DataHoraCriacao || reserva.DataHoraCriacao >= res.DataHoraFim))
                {
                    throw new InvalidOperationException("Já existe uma reserva para esta sala nesse período.");
                }
                if (res.SalaId == reserva.SalaId
                    && reserva.QuantidadePessoa > res.Sala.CapacidadeMaxima)
                {
                    throw new InvalidOperationException("Não é possível fazer uma reserva que ultrapasse a quantidade máxima de pessoas da Sala.");
                }
            }
        }
    }
}
