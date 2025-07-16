using DesafioASC.Domain.Entities;

namespace DesafioASC.Domain.Interfaces
{
    public interface IReservaRepository : IBaseRepository<Reserva>
    {
        Task<Reserva> GetByIdWithSalaAsync(int id);
        Task<List<Reserva>> GetAllWithSalaAsync();

    }
}
