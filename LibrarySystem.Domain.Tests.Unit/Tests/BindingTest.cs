using FluentAssertions;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.Tests.Unit.Builders;
using LibrarySystem.Domain.Tests.Unit.Factories;

namespace LibrarySystem.Domain.Tests.Unit.Tests;

public class BindingTest

{
    private readonly BindingTestBuilder _bindingTestBuilder;
	public BindingTest()
	{
		_bindingTestBuilder = new BindingTestBuilder();
	}
    [Fact]
    public void Constructor_Binding_Property()
    {
        const string title = "Muli";
        var binding = new Binding(title);
        binding.Name.Should().Be(title);
        binding.Books.Should().BeEmpty();

    }
    [Fact]
    public void Constructor_Should_throw_Exception_When_IsNotProvided()
    {
        Action course = () => _bindingTestBuilder.WithName("").Build();
        course.Should().ThrowExactly<ArgumentNullException>();

    }
    [Fact]
    public void AddBook_Should_Add_NewBook_To_Books_When_IdAndNamePassed()
    {
        #region Arrange

        var binding = _bindingTestBuilder.Build();
        var bookToAdd = BookFactory.Create();
        #endregion

        #region Act
        binding.AddBook(bookToAdd);
        #endregion

        #region Assert
        binding.Books.Should().ContainEquivalentOf(bookToAdd);
        #endregion

    }

}
