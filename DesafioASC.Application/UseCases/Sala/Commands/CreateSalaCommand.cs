using DesafioASC.Domain.Entities;
using System.Text.Json.Serialization;

namespace DesafioASC.Application.UseCases.Sala.Commands
{
    public class CreateSalaCommand
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public DateTime DataHoraCriacao { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public int Id { get; set; }
    }
}


