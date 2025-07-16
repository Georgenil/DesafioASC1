using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioASC.Persistence.Repositories
{
    public class ReservaRepository : BaseRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Reserva> GetByIdWithSalaAsync(int id)
        {
            var reserva = await _context.Reservas
                        .Include(x => x.Sala)
                       .AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);

            return reserva ?? throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");
        }

        public async Task<IList<Reserva>> GetAllWithSalaAsync()
        {
            var reservas = await _context.Reservas
                        .Include(x => x.Sala)
                       .AsNoTracking()
                       .ToListAsync();

            return reservas;
        }
    }
}
