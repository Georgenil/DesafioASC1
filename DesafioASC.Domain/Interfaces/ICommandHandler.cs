namespace DesafioASC.Domain.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : class
    {
        Task Handle(TCommand command);
    }
}
