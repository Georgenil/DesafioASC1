namespace DesafioASC.Domain.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class
    {
        Task<TResult> Handle(TQuery query);
    }
}