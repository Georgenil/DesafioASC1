using DesafioASC.Domain.Entities;
using System.Text.Json.Serialization;

namespace DesafioASC.Application.UseCases.Sala.Commands
{
    public class CreateSalaCommand
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }

        [JsonIgnore]
        public int Id { get; internal set; }
    }
}


