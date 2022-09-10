using FluentAssertions;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Domain.Tests.Unit.Builders;

namespace LibrarySystem.Domain.Tests.Unit.Tests;

public class BookTest
{
    private readonly BookTestBuilder _bookTestBuilder;
    public BookTest()
    {
        _bookTestBuilder = new BookTestBuilder();
    }
    [Fact]
    public void Constructor_Book_Property()
    {
        const string title = "C#Programming";
        const string language = "english";
        const int publicationYear = 2017;
        const long bindingId = 1;
        const long categoryId = 1;

        var binding = new Book(title, language, publicationYear, bindingId, categoryId);
        binding.Title.Should().Be(title);
        binding.PublicationYear.Should().Be(publicationYear);
        binding.Language.Should().Be(language);
        binding.BindingId.Should().Be(bindingId);
        binding.CategoryId.Should().Be(categoryId);


    }
    [Fact]
    public void Constructor_Should_throw_Exception_When_IsNullTitle()
    {
        Action course = () => _bookTestBuilder.WithTitle("").Build();
        course.Should().ThrowExactly<ArgumentNullException>();
    }
    [Fact]
    public void Constructor_Should_throw_Exception_When_IsNullLanguage()
    {
        Action course = () => _bookTestBuilder.Withlanguage("").Build();
        course.Should().ThrowExactly<ArgumentNullException>();
    }
    

}
