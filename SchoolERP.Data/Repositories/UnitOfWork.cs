using SchoolERP.Data.DbContext;
using SchoolERP.Data.Interfaces;
using SchoolERP.Data.Repositories;
using System.Collections;

public class UnitOfWork : IUnitOfWork
{
    private readonly SchoolERPDbContext _context;
    private Hashtable _repositories;

    public UnitOfWork(SchoolERPDbContext context)
    {
        _context = context;
    }

    // 👇 Add this so services can use DbContext directly
    public SchoolERPDbContext Context => _context;

    public IRepository<T> Repository<T>() where T : class
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(T).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryInstance = new Repository<T>(_context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
