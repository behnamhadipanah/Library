using LibrarySystem.Domain.BookAgg;

namespace LibrarySystem.Domain.Tests.Unit.Builders;

public class BookTestBuilder
{
    private long _id = 1;
    private string _title = "";
    private string _language = "";
    private int _publicationYear = 2017;
    private long _bindingId = 1;
    private long _categoryId = 1;
    public Book Build()
    {
        return new Book(_title, _language, _publicationYear, _bindingId, _categoryId);
    }
    public BookTestBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }
    public BookTestBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public BookTestBuilder WithpublicationYear(int publicationYear)
    {
        _publicationYear = publicationYear;
        return this;
    }

    public BookTestBuilder Withlanguage(string language)
    {
        _language =language;
        return this;
    }

    public BookTestBuilder WithBindingId(long bindingId)
    {
        _bindingId = bindingId;
        return this;
    }

    public BookTestBuilder WithCategoryId(long categoryId)
    {
        _categoryId = categoryId;
        return this;
    }
}
