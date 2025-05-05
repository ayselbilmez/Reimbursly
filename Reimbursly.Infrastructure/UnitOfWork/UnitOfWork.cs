using Reimbursly.Application.Interfaces;
using Reimbursly.Infrastructure.Repositories;
using Reimbursly.Persistence.DbContext;

namespace Reimbursly.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ReimburslyDbContext _context;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(ReimburslyDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);

        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new Repository<T>(_context);
            _repositories[type] = repositoryInstance;
        }

        return (IRepository<T>)_repositories[type];
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
