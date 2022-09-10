
using LibrarySystem.Infrastructure.Contracts.Book;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Queries.BookQuery;

public interface IBookQuery
{
    Task<List<BookViewModel>> GetBooks();
    Task<BookViewModel?> GetBook(long id);
}
