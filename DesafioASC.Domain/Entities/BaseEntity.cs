namespace DesafioASC.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
        public DateTime? DataHoraAtualizacao { get; set; } = DateTime.Now;
    }
}
