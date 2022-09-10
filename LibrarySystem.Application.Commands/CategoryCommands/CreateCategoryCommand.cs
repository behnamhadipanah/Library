using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Category;
using LibrarySystem.Domain.BindingAgg.CategoryService;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.CategoryCommands;

public class CreateCategoryCommand : IRequestWrapper<bool>
{
	public CreateCategoryViewModel Category { get; set; }
	public CreateCategoryCommand(CreateCategoryViewModel model)
	{
		Category = model;
	}
}
public class CreateCategoryCommandHandler : IHandlerWrapper<CreateCategoryCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICategoryRepository _categoryRepository;
	private readonly ICategoryValidatorService _validatorService;
	public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository,ICategoryValidatorService validatorService)
	{
		_unitOfWork = unitOfWork;
		_categoryRepository = categoryRepository;
		_validatorService = validatorService;
	}

	public async Task<Response<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var category = new Category(request.Category.Title, _validatorService);
		await _categoryRepository.AddAsync(category);
		var result=_unitOfWork.CommitTransaction();

        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Insert Category"));

        return await Task.FromResult(Response.Fail<bool>("Error Insert Category"));
    }
}