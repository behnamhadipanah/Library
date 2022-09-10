using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BookCommands;

public class ActivateBookCommand : IRequestWrapper<bool>
{
    public long BookId { get; set; }
    public ActivateBookCommand(long bookId)
    {
        BookId = bookId;
    }
}

public class ActivateBookCommandHandler : IHandlerWrapper<ActivateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    public ActivateBookCommandHandler(IUnitOfWork unitOfWork,IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;  
    }

    public async Task<Response<bool>> Handle(ActivateBookCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var book = _bookRepository.GetBy(request.BookId);
        book.Activate();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Activate Book"));

        return await Task.FromResult(Response.Fail<bool>("Error Activate Book"));
    }
}
