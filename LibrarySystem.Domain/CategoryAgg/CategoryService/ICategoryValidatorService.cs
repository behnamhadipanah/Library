namespace LibrarySystem.Domain.BindingAgg.CategoryService;
public interface ICategoryValidatorService
{
    void CheckThatThisRecordAlreadyExists(string title);

}
