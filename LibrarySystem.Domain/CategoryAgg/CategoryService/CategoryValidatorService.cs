
using LibrarySystem.Domain.BindingAgg.CategoryService;
using LibrarySystem.Framework.Domain;

namespace LibrarySystem.Domain.CategoryAgg.CategoryService;

public class CategoryValidatorService : ICategoryValidatorService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryValidatorService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void CheckThatThisRecordAlreadyExists(string title)
    {
        if (_categoryRepository.Exists(x=>x.Title==title))
            throw new DuplicatedRecordException("This record already exists in database");

    }
}
