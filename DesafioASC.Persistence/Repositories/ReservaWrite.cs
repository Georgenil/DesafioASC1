using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;

namespace DesafioASC.Persistence.Repositories
{
    public class ReservaWrite : IReservaWrite
    {
        protected readonly AppDbContext _context;

        public ReservaWrite(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Reserva> CreateReservaAsync(Reserva entity)
        {
            entity.DataHoraCriacao = DateTime.Now;
            await _context.Reservas.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var entity = await _context.Reservas.FindAsync(id);
            if (entity == null) return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Reserva> UpdateReservaAsync(Reserva entity)
        {
            entity.DataHoraAtualizacao = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}