using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BindingCommands;

public class DeactivateBindingCommand : IRequestWrapper<bool>
{
    public long BindingId { get; set; }
    public DeactivateBindingCommand(long bindingId)
    {
        BindingId = bindingId;
    }
}

public class DeactivateBindingCommandHandler : IHandlerWrapper<DeactivateBindingCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBindingRepository _bindingRepository;
    public DeactivateBindingCommandHandler(IUnitOfWork unitOfWork, IBindingRepository bindingRepository)
    {
        _unitOfWork = unitOfWork;
        _bindingRepository = bindingRepository;
    }

    public async Task<Response<bool>> Handle(DeactivateBindingCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var binding = _bindingRepository.GetBy(request.BindingId);
        binding.Deactive();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deactive Binding"));

        return await Task.FromResult(Response.Fail<bool>("Error Deactive Binding"));
    }
}
