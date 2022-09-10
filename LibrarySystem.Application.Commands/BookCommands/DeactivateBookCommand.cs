using LibrarySystem.Application.Contract;
using LibrarySystem.Domain.BindingAgg;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Domain.CategoryAgg;
using LibrarySystem.Framework.Infrastructure;

namespace LibrarySystem.Application.Commands.BookCommands;

public class DeactivateBookCommand : IRequestWrapper<bool>
{
    public long BookId { get; set; }
    public DeactivateBookCommand(long bookId)
    {
        BookId = bookId;
    }
}

public class DeactivateBookCommandHandler : IHandlerWrapper<DeactivateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    public DeactivateBookCommandHandler(IUnitOfWork unitOfWork,IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;  
    }

    public async Task<Response<bool>> Handle(DeactivateBookCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var book = _bookRepository.GetBy(request.BookId);
        book.Deactive();
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Deactive Book"));

        return await Task.FromResult(Response.Fail<bool>("Error Deactive Book"));
    }
}
