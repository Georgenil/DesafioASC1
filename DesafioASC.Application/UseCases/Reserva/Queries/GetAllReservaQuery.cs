namespace DesafioASC.Application.UseCases.Reserva.Queries
{
    public class GetAllReservaQuery
    {
        public DateTime DataHoraCriacao { get; set; }
        public DateTime DataHoraFim { get; set; }
        public int QuantidadePessoa { get; set; }
        public DateTime? DataHoraAtualizacao { get; set; } 
        public int SalaId { get; set; }
        public Domain.Entities.Sala Sala { get; set; }
    }
}
