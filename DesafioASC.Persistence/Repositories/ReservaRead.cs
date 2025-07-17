using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioASC.Persistence.Repositories
{
    public class ReservaRead : IReservaRead
    {
        protected readonly AppDbContext _context;
        public ReservaRead(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            var entity = await _context.Reservas.AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);

            return entity ?? throw new KeyNotFoundException($"Item com ID {id} não encontrado.");
        }

        public async Task<List<Reserva>> GetAllReservaAsync()
        {
            return await _context.Reservas.AsNoTracking()
                   .ToListAsync();
        }

        public async Task<Reserva> GetReservaByIdWithAsync(int id)
        {
            var reserva = await _context.Reservas.Include(x => x.Sala)
                                  .AsNoTracking()
                                  .FirstOrDefaultAsync(p => p.Id == id);

            return reserva ?? throw new KeyNotFoundException($"Reserva com ID {id} não encontrada.");
        }

        public async Task<List<Reserva>> GetAllReservaWithSalaAsync()
        {
            var reservas = await _context.Reservas
                        .Include(x => x.Sala)
                       .AsNoTracking()
                       .ToListAsync();

            return reservas;
        }
    }
}
