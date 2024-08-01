using System.Linq.Expressions;
using CodePulse.API.Models;

namespace CodePulse.API.Repository.Interface
{
    // Generic repository interface for CRUD operations
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}