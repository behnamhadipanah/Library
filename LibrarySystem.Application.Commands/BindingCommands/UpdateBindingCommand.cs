using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Binding;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;


namespace LibrarySystem.Application.Commands.BindingCommands;

public class UpdateBindingCommand : IRequestWrapper<bool>
{
    public EditBindingViewModel Binding { get; set; }
    public UpdateBindingCommand(EditBindingViewModel model)
    {
        Binding = model;
    }
}
public class UpdateBindingCommandHandler : IHandlerWrapper<UpdateBindingCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBindingRepository _bindingRepository;
    public UpdateBindingCommandHandler(IUnitOfWork unitOfWork, IBindingRepository bindingRepository)
    {
        _unitOfWork = unitOfWork;
        _bindingRepository = bindingRepository;
    }

    public async Task<Response<bool>> Handle(UpdateBindingCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var binding = await _bindingRepository.GetAsyncBy(request.Binding.Id);
        binding.Edit(request.Binding.Name);
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Update Binding"));

        return await Task.FromResult(Response.Fail<bool>("Error Update Binding"));
    }
}
