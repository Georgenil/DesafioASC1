using DesafioASC.Domain.Entities;
using System.Threading.Tasks;

namespace DesafioASC.Domain.Interfaces
{
    public interface IReservaWrite
    {
        Task<Reserva> CreateReservaAsync(Reserva entity);
        Task<Reserva> UpdateReservaAsync(Reserva entity);
        Task<bool> DeleteReservaAsync(int id);
    }
}
