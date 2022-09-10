using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Infrastructure;


namespace LibrarySystem.Application.Commands.BookCommands;

public class DeleteBookCommand:IRequestWrapper<bool>
{
    public long Id { get; set; }
	public DeleteBookCommand(long bookId)
	{
		Id = bookId;
	}
}

public class DeleteBookCommandHandler : IHandlerWrapper<DeleteBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
	public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<Response<bool>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();
		var book= await _bookRepository.GetAsyncBy(request.Id);
        book.Deleted();
		var result=_unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deleted Book"));

        return await Task.FromResult(Response.Fail<bool>("Error Deleted Book"));
    }
}
