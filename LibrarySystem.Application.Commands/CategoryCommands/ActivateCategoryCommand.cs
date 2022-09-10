using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.CategoryCommands;

public class ActivateCategoryCommand : IRequestWrapper<bool>
{
    public long CategoryId { get; set; }
    public ActivateCategoryCommand(long categoryId)
    {
        CategoryId = categoryId;
    }
}

public class ActivateCategoryCommandHandler : IHandlerWrapper<ActivateCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public ActivateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }
    public async Task<Response<bool>> Handle(ActivateCategoryCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var category = _categoryRepository.GetBy(request.CategoryId);
        category.Activate();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Activate Category"));

        return await Task.FromResult(Response.Fail<bool>("Error Activate Category"));
    }
}
