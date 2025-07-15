namespace DesafioASC.Domain.Entities
{
    public class Reserva : BaseEntity
    {
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
       
    }
}