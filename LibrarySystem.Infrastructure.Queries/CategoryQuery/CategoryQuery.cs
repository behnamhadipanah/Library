using LibrarySystem.Infrastructure.Contracts.Category;
using LibrarySystem.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LibrarySystem.Infrastructure.Queries.CategoryQuery;

public class CategoryQuery : ICategoryQuery
{
    private readonly LibraryDbContext _context;
    public CategoryQuery(LibraryDbContext context)
    {
        _context = context;
    }

    public Task<List<CategoryViewModel>> GetCategories()
    {
        return _context.Categories.Select(x => new CategoryViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            IsActive = x.IsActive,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().ToListAsync();
    }

    public Task<CategoryViewModel?> GetCategory(long id)
    {
        return _context.Categories.Where(x => x.Id == id).Select(x => new CategoryViewModel()
        {
            Id = x.Id,
            Title = x.Title,
            IsActive = x.IsActive,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().SingleOrDefaultAsync();
    }
}