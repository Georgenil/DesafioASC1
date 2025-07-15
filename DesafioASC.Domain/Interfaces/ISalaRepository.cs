using DesafioASC.Domain.Entities;

namespace DesafioASC.Domain.Interfaces
{
    public interface ISalaRepository
    {
        Task<Sala> CreateSalaAsync(Sala sala);
        Task<Sala> UpdateSalaAsync(Sala sala);
        Task<bool> DeleteSalaAsync(int id);
        Task<Sala> GetSalaByIdAsync(int id);
        Task<List<Sala>> GetAllSalaAsync();
    }
}
