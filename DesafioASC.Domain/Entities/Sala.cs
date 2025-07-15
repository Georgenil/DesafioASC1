namespace DesafioASC.Domain.Entities
{
    public class Sala : BaseEntity
    {
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
        public IList<Reserva>? Reservas { get; set; }
    }
}
