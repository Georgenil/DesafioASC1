using System;
using System.Text.Json.Serialization;

namespace DesafioASC.Application.UseCases.Reserva.Commands
{
    public class CreateReservaCommand
    {
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraFim { get; set; }
        public int QuantidadePessoa { get; set; }

        public int SalaId { get; set; }

        [JsonIgnore]
        public int Id { get; set; }
    }
}
