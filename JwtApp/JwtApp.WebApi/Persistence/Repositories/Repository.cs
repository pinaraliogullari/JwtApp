using JwtApp.WebApi.Core.Application.Interfaces;
using JwtApp.WebApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApp.WebApi.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly JwtAppContext _context;

        public Repository(JwtAppContext context)
        {
            _context = context;
        }

        public DbSet<T> Table=>_context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()=>
            await Table.AsNoTracking().ToListAsync();


        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter) =>
             await Table.AsNoTracking().SingleOrDefaultAsync(filter);



        public async Task<T?> GetByIdAsync(object id) =>
            await Table.FindAsync(id);
       

        public async Task RemoveAsync(T entity)
        {
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
