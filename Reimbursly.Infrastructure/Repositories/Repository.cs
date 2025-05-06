using Microsoft.EntityFrameworkCore;
using Reimbursly.Application.Interfaces;
using Reimbursly.Persistence.DbContext;
using System.Linq.Expressions;

namespace Reimbursly.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ReimburslyDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ReimburslyDbContext context)
    {
        _context = context;
        _entities = _context.Set<T>();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _entities.FindAsync(id);
    }

    public async Task<T?> GetAsync(
    Expression<Func<T, bool>> predicate,
    Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        return await query.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<T>> FindAsync(
        Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IQueryable<T>>? include = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        return await query.Where(predicate).ToListAsync();
    }

    public IQueryable<T> GetQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }

    public async Task AddAsync(T entity)
    {
        await _entities.AddAsync(entity);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public void Remove(T entity)
    {
        _entities.Remove(entity);
    }
}
