using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Binding;
using LibrarySystem.Application.Contract.Book;
using LibrarySystem.Application.Contract.Category;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BindingAgg.BindingService;
using LibrarySystem.Domain.BindingAgg.CategoryService;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.DomainService.BookService;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BookCommands;

public class CreateBookCommand : IRequestWrapper<bool>
{
	public CreateBookViewModel Book { get; set; }
	public CreateBookCommand(CreateBookViewModel model)
	{
        Book = model;
	}
}
public class CreateBookCommandHandler : IHandlerWrapper<CreateBookCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    private readonly IBookValidatorService _validatorService;
	public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository, IBookValidatorService validatorService)
	{
		_unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
		_validatorService = validatorService;
	}

	public async Task<Response<bool>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var binding = new Book(request.Book.Title,request.Book.Language,request.Book.PublicationYear,request.Book.BindingId,request.Book.CategoryId, _validatorService);
		await _bookRepository.AddAsync(binding);
		var result=_unitOfWork.CommitTransaction();

        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Insert Book"));

        return await Task.FromResult(Response.Fail<bool>("Error Insert Book"));
    }
}