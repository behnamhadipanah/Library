using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BindingCommands;

public class ActivateBindingCommand : IRequestWrapper<bool>
{
    public long BindingId { get; set; }
    public ActivateBindingCommand(long bindingId)  
    {
        BindingId = bindingId;
    }
}

public class ActivateBindingCommandHandler : IHandlerWrapper<ActivateBindingCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBindingRepository _bindingRepository;
    public ActivateBindingCommandHandler(IUnitOfWork unitOfWork, IBindingRepository bindingRepository)
    {
        _unitOfWork = unitOfWork;
        _bindingRepository = bindingRepository;
    }

    public async Task<Response<bool>> Handle(ActivateBindingCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var binding = _bindingRepository.GetBy(request.BindingId);
        binding.Activate();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Activate Binding"));

        return await Task.FromResult(Response.Fail<bool>("Error Activate Binding"));
    }
}
