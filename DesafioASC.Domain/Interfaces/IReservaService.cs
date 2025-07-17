using DesafioASC.Domain.Entities;

namespace DesafioASC.Persistence.Services
{
    public interface IReservaService 
    {
        Task<Reserva> GetReservaByIdAsync(int id);
        Task<List<Reserva>> GetAllReservaAsync();
        Task<Reserva> GetReservaByIdWithAsync(int id);
        Task<List<Reserva>> GetAllReservaWithSalaAsync();
        Task<Reserva> CreateReservaAsync(Reserva entity);
        Task<Reserva> UpdateReservaAsync(Reserva entity);
        Task<bool> DeleteReservaAsync(int id);
    }
}
