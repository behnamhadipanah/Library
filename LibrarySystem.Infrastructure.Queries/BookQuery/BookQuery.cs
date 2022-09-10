
using LibrarySystem.Infrastructure.Contracts.Book;
using LibrarySystem.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace LibrarySystem.Infrastructure.Queries.BookQuery;

public class BookQuery : IBookQuery
{
    private readonly LibraryDbContext _context;
    public BookQuery(LibraryDbContext context)
    {
        _context = context;
    }

    public Task<BookViewModel?> GetBook(long id)
    {
        return _context.Books.Where(x => x.Id == id).Include(x => x.Binding).Include(x => x.Category).Select(x => new BookViewModel()
        {
            Title = x.Title,
            PublicationYear = x.PublicationYear,
            Binding = x.Binding.Name,
            Category = x.Category.Title,
            IsActive = x.IsActive,
            Language = x.Language,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().SingleOrDefaultAsync();
    }

    public Task<List<BookViewModel>> GetBooks()
    {
        return _context.Books.Include(x => x.Binding).Include(x => x.Category).Select(x => new BookViewModel()
        {
            Title = x.Title,
            PublicationYear = x.PublicationYear,
            Binding = x.Binding.Name,
            Category = x.Category.Title,
            IsActive = x.IsActive,
            Language = x.Language,
            CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).AsNoTracking().ToListAsync();
    }
}