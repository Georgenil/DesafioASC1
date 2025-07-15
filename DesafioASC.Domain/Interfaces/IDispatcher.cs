namespace DesafioASC.Domain.Interfaces
{
    public interface IDispatcher
    {
        Task Dispatch<TCommand>(TCommand command) where TCommand : class;
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : class;
    }
}
