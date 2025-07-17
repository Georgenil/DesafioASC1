using DesafioASC.Domain.Entities;

namespace DesafioASC.Domain.Interfaces
{
    public interface IReservaRead
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<List<Reserva>> GetAllReservaAsync();
        Task<Reserva> GetReservaByIdWithAsync(int id);
        Task<List<Reserva>> GetAllReservaWithSalaAsync();
    }
}
