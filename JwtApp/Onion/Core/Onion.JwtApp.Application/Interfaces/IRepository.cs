using System.Linq.Expressions;

namespace Onion.JwtApp.Application.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter);
        Task<T?> CreateAsync(T entity);
        Task Update(T entity);
        Task Remove(T entity);
        Task<int> SaveChangesAsync();
    }
}
