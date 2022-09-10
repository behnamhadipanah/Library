using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Framework.Infrastructure;


namespace LibrarySystem.Application.Commands.BindingCommands;

public class DeleteBindingCommand : IRequestWrapper<bool>
{
    public long Id { get; set; }
	public DeleteBindingCommand(long bindingId)
	{
		Id = bindingId;
	}
}

public class DeleteBindingCommandHandler : IHandlerWrapper<DeleteBindingCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBindingRepository _bindingRepository;
	public DeleteBindingCommandHandler(IUnitOfWork unitOfWork, IBindingRepository bindingRepository)
	{
		_unitOfWork = unitOfWork;
		_bindingRepository = bindingRepository;
	}

	public async Task<Response<bool>> Handle(DeleteBindingCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var binding= await _bindingRepository.GetAsyncBy(request.Id);
		binding.Deleted();
		var result=_unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deleted Binding"));

        return await Task.FromResult(Response.Fail<bool>("Error Deleted Binding"));
    }
}
