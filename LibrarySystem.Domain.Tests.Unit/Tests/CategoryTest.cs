using FluentAssertions;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Domain.Tests.Unit.Builders;
using LibrarySystem.Domain.Tests.Unit.Factories;

namespace LibrarySystem.Domain.Tests.Unit.Tests
{
    public class CategoryTest
    {
        private readonly CategoryTestBuilder _categoryTestBuilder;
        public CategoryTest()
        {
            _categoryTestBuilder = new CategoryTestBuilder();
        }

        [Fact]
        public void Constructor_Category_Property()
        {
            const string title = "Drama";
            var category = new Category(title);
            category.Title.Should().Be(title);
            category.Books.Should().BeEmpty();
        }
        [Fact]
        public void Constructor_Should_throw_Exception_When_IsNotProvided()
        {
            Action course = () => _categoryTestBuilder.WithTitle("").Build();
            course.Should().ThrowExactly<ArgumentNullException>();

        }

        [Fact]
        public void AddBook_Should_Add_NewBook_To_Books_When_IdAndNamePassed()
        {
            #region Arrange

            var category = _categoryTestBuilder.Build();
            var bookToAdd = BookFactory.Create();
            #endregion

            #region Act
            category.AddBook(bookToAdd);
            #endregion

            #region Assert
            category.Books.Should().ContainEquivalentOf(bookToAdd);
            #endregion

        }
    }
}