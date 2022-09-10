using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Book;
using LibrarySystem.Domain.BookAgg;
using LibrarySystem.Framework.Infrastructure;


namespace LibrarySystem.Application.Commands.BookCommands;

public class UpdateBookCommand : IRequestWrapper<bool>
{
    public EditBookViewModel Book { get; set; }
    public UpdateBookCommand(EditBookViewModel model)
    {
        Book = model;
    }
}
public class UpdateBookCommandHandler : IHandlerWrapper<UpdateBookCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<Response<bool>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.BeginTransaction();
        var book = await _bookRepository.GetAsyncBy(request.Book.Id);
        book.Edit(request.Book.Title, request.Book.Language, request.Book.PublicationYear, request.Book.BindingId, request.Book.CategoryId);
        var result = _unitOfWork.CommitTransaction();
        if (result)
            return await Task.FromResult(Response.Ok<bool>("Success Update Book"));

        return await Task.FromResult(Response.Fail<bool>("Error Update Book"));
    }
}
