using DesafioASC.Domain.Entities;

namespace DesafioASC.Domain.Interfaces
{
    public interface ISalaRepository : IBaseRepository<Sala>
    {
        Task<Sala> GetSalaAsync(System.Linq.Expressions.Expression<Func<Sala, bool>> predicate);
    }
}
