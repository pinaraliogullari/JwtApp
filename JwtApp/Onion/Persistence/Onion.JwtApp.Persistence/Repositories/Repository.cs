using Microsoft.EntityFrameworkCore;
using Onion.JwtApp.Application.Interfaces;
using Onion.JwtApp.Persistence.Context;
using System.Linq.Expressions;

namespace Onion.JwtApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly OnionJwtContext _context;

        public Repository(OnionJwtContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public async Task<T?> CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync() =>
            await Table.AsNoTracking().ToListAsync();


        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter) =>
            await Table.AsNoTracking().SingleOrDefaultAsync(filter);

        public async Task<T?> GetByIdAsync(object id) =>
            await Table.FindAsync(id);

        public async Task Remove(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync()=>
            _context.SaveChangesAsync();

        public async Task Update(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
