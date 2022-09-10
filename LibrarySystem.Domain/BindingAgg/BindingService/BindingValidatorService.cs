using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BindingAgg.BindingService;
using LibrarySystem.Framework.Domain;

namespace LibrarySystem.DomainService.BindingService;

public class BindingValidatorService : IBindingValidatorService
{
    private readonly IBindingRepository _bindingRepository;
    public BindingValidatorService(IBindingRepository bindingRepository)
    {
        _bindingRepository = bindingRepository;
    }

    public void CheckThatThisRecordAlreadyExists(string name)
    {
        if (_bindingRepository.Exists(x => x.Name == name))
            throw new DuplicatedRecordException("This record already exists in database");
    }
}