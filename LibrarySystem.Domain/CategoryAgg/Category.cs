using LibrarySystem.Domain.BindingAgg.CategoryService;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace LibrarySystem.Domain.CategoryAgg;

public class Category:DomainBase
{
    #region Properties
    public string Title { get; private set; }
    public ICollection<Book> Books { get; private set; }

    #endregion

    #region Constructors
    protected Category()
    {

    }
    public Category(string title,ICategoryValidatorService validatorService)
    {
        GuardAgainstEmpty(title);
        validatorService.CheckThatThisRecordAlreadyExists(title);
        Title = title;
        Books = new List<Book>();
    }
    public Category(string title)
    {
        GuardAgainstEmpty(title);
        Title = title;
        Books = new List<Book>();
    }

    #endregion

    #region Methods
    private void GuardAgainstEmpty(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException(title);
    }
    public void AddBook(Book book)
    {
        Books.Add(book);
    }
    public void Edit(string title)
    {
        GuardAgainstEmpty(title);
        Title = title;
    }
    #endregion
}
