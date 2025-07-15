namespace DesafioASC.Application.UseCases.Sala.Commands
{
    public class UpdateSalaCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CapacidadeMaxima { get; set; }
    }
}
