using LibrarySystem.Domain.BindingAgg.BindingService;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Domain;
namespace LibrarySystem.Domain.BindingAgg;

public class Binding : DomainBase
{
    #region Properties
    public string Name { get; private set; }
    public ICollection<Book> Books { get; private set; }
    #endregion

    #region Constructors
    protected Binding()
    {

    }
    public Binding(string name, IBindingValidatorService validatorService)
    {
        GuardAgainstEmpty(name);
        validatorService.CheckThatThisRecordAlreadyExists(name);
        Name = name;
        Books = new List<Book>();
    }
    public Binding(string name)
    {
        GuardAgainstEmpty(name);
        Name = name;
        Books = new List<Book>();
    }


    #endregion

    #region Methods
    public void Edit(string name)
    {
        GuardAgainstEmpty(name);
        Name = name;
    }
    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    private void GuardAgainstEmpty(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(name);
    }
    #endregion
}
