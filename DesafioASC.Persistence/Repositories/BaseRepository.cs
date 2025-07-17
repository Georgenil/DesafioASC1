using DesafioASC.Domain.Entities;
using DesafioASC.Domain.Interfaces;
using DesafioASC.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DesafioASC.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            entity.DataHoraCriacao = DateTime.UtcNow;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>()
           .AsNoTracking()
           .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>()
                       .AsNoTracking()
                       .FirstOrDefaultAsync(p => p.Id == id);

            return entity ?? throw new KeyNotFoundException($"Item com ID {id} não encontrado.");
        }



        public async Task<T> UpdateAsync(T entity)
        {
            entity.DataHoraAtualizacao = DateTime.UtcNow;
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
