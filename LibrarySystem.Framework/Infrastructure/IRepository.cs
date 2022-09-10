using LibrarySystem.Framework.Domain;
using System.Linq.Expressions;

namespace LibrarySystem.Framework.Infrastructure;
public interface IRepository<TEntity> where TEntity : DomainBase
{
    bool Exists(Expression<Func<TEntity, bool>> expression);
    TEntity GetBy(long id);
    Task<TEntity> GetAsyncBy(long id);
    Task AddAsync(TEntity entity);
    void Add(TEntity entity);
}
