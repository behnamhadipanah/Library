using LibrarySystem.Infrastructure.Contracts.Category;


namespace LibrarySystem.Infrastructure.Queries.CategoryQuery;

public interface ICategoryQuery
{
    Task<List<CategoryViewModel>> GetCategories();
    Task<CategoryViewModel?> GetCategory(long id);
}
