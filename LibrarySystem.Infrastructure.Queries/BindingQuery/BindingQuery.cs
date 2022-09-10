using LibrarySystem.Infrastructure.Contracts.Binding;
using LibrarySystem.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LibrarySystem.Infrastructure.Queries.BindingQuery;

public class BindingQuery : IBindingQuery
{
    private readonly LibraryDbContext _context;
    public BindingQuery(LibraryDbContext context)
    {
        _context = context;
    }

    public Task<BindingViewModel?> GetBinding(long id)
    {
        return _context.Bindings.Where(x=>x.Id==id).Select(x => new BindingViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            IsActive = x.IsActive,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().SingleOrDefaultAsync();
    }

    public Task<List<BindingViewModel>> GetBindings()
    {
        return _context.Bindings.Select(x => new BindingViewModel()
        {
            Id = x.Id,
            Name = x.Name,
            IsActive = x.IsActive,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().ToListAsync();
    }
}