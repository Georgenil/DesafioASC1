using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioASC.Persistence.Repositories
{
    public class SalaRepository : BaseRepository<Sala>, ISalaRepository
    {
        public SalaRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Sala> GetByIdWithReservaAsync(int id)
        {
            var sala = await _context.Salas
                        .Include(x => x.Reservas)
                       .AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);

            return sala ?? throw new KeyNotFoundException($"Sala com ID {id} não encontrada.");
        }
    }
}
