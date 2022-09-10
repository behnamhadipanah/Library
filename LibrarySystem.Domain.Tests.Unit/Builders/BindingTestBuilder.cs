

using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.DomainService.BindingService;

namespace LibrarySystem.Domain.Tests.Unit.Builders;

public class BindingTestBuilder
{
    private long _id = 1;
    private string _name = "";
    public Binding Build()
    {

        return new Binding(_name);
    }
    public BindingTestBuilder WithName(string name)
    {
        _name = name;
        return this;
    }
    public BindingTestBuilder WithId(long id)
    {
        _id = id;
        return this;
    }
}
