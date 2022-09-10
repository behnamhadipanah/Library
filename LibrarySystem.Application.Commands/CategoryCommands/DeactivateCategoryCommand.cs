using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.CategoryCommands;

public class DeactivateCategoryCommand : IRequestWrapper<bool>
{
    public long CategoryId { get; set; }
    public DeactivateCategoryCommand(long categoryId)
    {
        CategoryId = categoryId;
    }
}

public class DeactivateCategoryCommandHandler : IHandlerWrapper<DeactivateCategoryCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public DeactivateCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }
    public async Task<Response<bool>> Handle(DeactivateCategoryCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var category = _categoryRepository.GetBy(request.CategoryId);
        category.Deactive();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deactive Category"));

        return await Task.FromResult(Response.Fail<bool>("Error Deactive Category"));
    }
}
