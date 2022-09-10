using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Commands.CategoryCommands;

public class DeleteCategoryCommand : IRequestWrapper<bool>
{
    public long Id { get; set; }
	public DeleteCategoryCommand(long categoryId)
	{
		Id = categoryId;
	}
}

public class DeleteCategoryCommandHandler : IHandlerWrapper<DeleteCategoryCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICategoryRepository _categoryRepository;
	public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
	{
		_unitOfWork = unitOfWork;
		_categoryRepository = categoryRepository;
	}

	public async Task<Response<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var category= await _categoryRepository.GetAsyncBy(request.Id);
		category.Deleted();
		var result=_unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deleted Category"));

        return await Task.FromResult(Response.Fail<bool>("Error Deleted Category"));
    }
}
