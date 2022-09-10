using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Domain;

namespace LibrarySystem.DomainService.BookService;

public class BookValidatorService : IBookValidatorService
{
    private readonly IBookRepository _bookRepository;
    public BookValidatorService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void CheckThatThisRecordAlreadyExists(string title, string language, long publicationYear, long bindingId, long categoryId)
    {
        if (_bookRepository.Exists(x => x.Title == title &&
        x.Language == language &&
        x.PublicationYear == publicationYear &&
        x.BindingId == bindingId &&
         x.CategoryId == categoryId))
            throw new DuplicatedRecordException("This record already exists in database");
    }
}
