namespace DesafioASC.Application.UseCases.Sala.Queries
{
    public class GetAllSalaQuery
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public IList<Domain.Entities.Reserva>? Reservas { get; set; }
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
    }
}
