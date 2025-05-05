using System.Linq.Expressions;

namespace Reimbursly.Application.Interfaces;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetQueryable();
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
}
