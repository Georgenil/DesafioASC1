namespace DesafioASC.Domain.Entities
{
    public class Reserva : BaseEntity
    {
        public DateTime DataHoraFim { get; set; }
        public int QuantidadePessoa { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
       
    }
}