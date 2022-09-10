using LibrarySystem.Domain.CategoryAgg;


namespace LibrarySystem.Domain.Tests.Unit.Builders;

public class CategoryTestBuilder
{
    private long _id = 1;
    private string _title = "";
    public Category Build()
    {
        
        return new Category(_title);
    }
    public CategoryTestBuilder WithTitle(string title)
    {
        _title=title;
        return this;
    }
    public CategoryTestBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
}
