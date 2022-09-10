using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Category;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.CategoryCommands;

public class UpdateCategoryCommand : IRequestWrapper<bool>
{
    public EditCategoryViewModel Category { get; set; }
    public UpdateCategoryCommand(EditCategoryViewModel model)
    {
        Category = model;
    }
}
public class UpdateCategoryCommandHandler : IHandlerWrapper<UpdateCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<Response<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var category = await _categoryRepository.GetAsyncBy(request.Category.Id);
        category.Edit(request.Category.Title);
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Update Category"));

        return await Task.FromResult(Response.Fail<bool>("Error Update Category"));
    }
}
