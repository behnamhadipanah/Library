using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Infrastructure.EfCore.Repositories;

public class BookRepository:Repository<Book>,IBookRepository
{
    private readonly LibraryDbContext _context;
	public BookRepository(LibraryDbContext context):base(context)
	{
		_context = context;
	}
}
