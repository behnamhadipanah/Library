using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.DomainService.BookService;
using LibrarySystem.Framework.Domain;


namespace LibrarySystem.Domain.BookAgg;

public class Book : DomainBase
{
    #region Properties
    public string Title { get; private set; }
    public string Language { get; private set; }
    public long PublicationYear { get; private set; }

    public long BindingId { get; private set; }
    public long CategoryId { get; private set; }

    public Binding Binding { get; private set; }
    public Category Category { get; private set; }
    #endregion


    #region Constructors
    protected Book()
    {

    }
    public Book(string title, string language, long publicationYear, long bindingId, long categoryId, IBookValidatorService bookValidatorService)
    {
        GuardAgainstEmpty(title, language, publicationYear, bindingId, categoryId);
        bookValidatorService.CheckThatThisRecordAlreadyExists(title, language, publicationYear, bindingId, categoryId);
        Title = title;
        Language = language;
        PublicationYear = publicationYear;
        BindingId = bindingId;
        CategoryId = categoryId;
    }
    public Book(string title, string language, long publicationYear, long bindingId, long categoryId)
    {
        GuardAgainstEmpty(title, language, publicationYear, bindingId, categoryId);

        Title = title;
        Language = language;
        PublicationYear = publicationYear;
        BindingId = bindingId;
        CategoryId = categoryId;
    }
    #endregion

    #region Methods
    public void Edit(string title, string language, long publicationYear, long bindingId, long categoryId)
    {
        GuardAgainstEmpty(title, language, publicationYear, bindingId, categoryId);

        Title = title;
        Language = language;
        PublicationYear = publicationYear;
        BindingId = bindingId;
        CategoryId = categoryId;
    }
    private void GuardAgainstEmpty(string title, string language, long publicationYear, long bindingId, long categoryId)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(title);
        if (string.IsNullOrWhiteSpace(language))
            throw new ArgumentNullException(language);
        if (publicationYear <= 0)
            throw new ArgumentOutOfRangeException();
        if (bindingId <= 0)
            throw new ArgumentOutOfRangeException();
        if (categoryId <= 0)
            throw new ArgumentOutOfRangeException();
    }
    #endregion

}
