using LibrarySystem.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibrarySystem.Framework.Infrastructure;

public class Repository<TEntity>:IRepository<TEntity> where TEntity : DomainBase
{
    private readonly DbContext _context;
    public Repository(DbContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        _context.Add(entity);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }

    public bool Exists(Expression<Func<TEntity, bool>> expression)
    {
        return _context.Set<TEntity>().Any(expression);
    }

 

  

    public async Task<TEntity> GetAsyncBy(long id)
    {
        return await _context.FindAsync<TEntity>(id);
    }

    public TEntity GetBy(long id)
    {
        return _context.Find<TEntity>(id);
    }
}
