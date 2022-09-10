using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Binding;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BindingAgg.BindingService;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BindingCommands;

public class CreateBindingCommand : IRequestWrapper<bool>
{
	public CreateBindingViewModel Binding { get; set; }
	public CreateBindingCommand(CreateBindingViewModel model)
	{
        Binding = model;
	}
}
public class CreateBindingCommandHandler : IHandlerWrapper<CreateBindingCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;
    private readonly IBindingRepository _bindingRepository;
    private readonly IBindingValidatorService _validatorService;
	public CreateBindingCommandHandler(IUnitOfWork unitOfWork, IBindingRepository bindingRepository, IBindingValidatorService validatorService)
	{
		_unitOfWork = unitOfWork;
		_bindingRepository = bindingRepository;
		_validatorService = validatorService;
	}

	public async Task<Response<bool>> Handle(CreateBindingCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var binding = new Binding(request.Binding.Name, _validatorService);
		await _bindingRepository.AddAsync(binding);
		var result=_unitOfWork.CommitTransaction();

        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Insert Binding"));

        return await Task.FromResult(Response.Fail<bool>("Error Insert Binding"));
    }
}