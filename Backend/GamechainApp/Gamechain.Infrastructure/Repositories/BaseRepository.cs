using Gamechain.Application.Interfaces.Repositories;
using Gamechain.Domain.Entities.Common;
using Gamechain.Infrastructure.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;

namespace Gamechain.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : AggregateRoot
    {
        private readonly GamechainDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(GamechainDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public Task<T?> GetById(Guid id)
        {
            return _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Create(T entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
