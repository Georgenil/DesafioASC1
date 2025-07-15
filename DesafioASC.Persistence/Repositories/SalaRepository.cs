using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioASC.Persistence.Repositories
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _context;
        public SalaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Sala> CreateSalaAsync(Sala sala)
        {
            await _context.Salas.AddAsync(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task<bool> DeleteSalaAsync(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null) return false;

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Sala>> GetAllSalaAsync()
        {
            return await _context.Salas
           .AsNoTracking()
           .ToListAsync();
        }

        public async Task<Sala> GetSalaByIdAsync(int id)
        {
            var sala = await _context.Salas
                        .Include(x => x.Reservas)
                       .AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);

            return sala ?? throw new KeyNotFoundException($"Sala com ID {id} não encontrado.");
        }

        public async Task<Sala> UpdateSalaAsync(Sala sala)
        {
            _context.Salas.Update(sala);
            await _context.SaveChangesAsync();
            return sala;
        }
    }
}
