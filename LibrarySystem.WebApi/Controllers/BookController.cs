using LibrarySystem.Application.Commands.BookCommands;
using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Book;
using LibrarySystem.Infrastructure.Contracts.Book;
using LibrarySystem.Infrastructure.Queries.BookQuery;
using LibrarySystem.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ApiBaseController  
    {
        private readonly IBookQuery _bookQuery;
        public BookController(IBookQuery bookQuery)
        {
            _bookQuery = bookQuery;
        }
        /// <summary>
        /// Get Books List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<List<BookViewModel>>> Get()
        {
            var result = _bookQuery.GetBooks();
            return await Task.FromResult(Application.Contract.Response.Ok
                ("Success", result.Result));
        }
        /// <summary>
        /// Add Book 
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response<bool>> Add([FromBody] CreateBookViewModel model)
        {
            return await Mediator.Send(new CreateBookCommand(model));

        }

        /// <summary>
        /// Update Book
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Response<bool>> Edit([FromBody] EditBookViewModel model)
        {
            return await Mediator.Send(new UpdateBookCommand(model));
        }
        /// <summary>
        /// Delete Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Response<bool>> Delete(long bookId)
        {
            return await Mediator.Send(new DeleteBookCommand(bookId));
        }
        /// <summary>
        /// Activate Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Activate/{id}")]
        public async Task<Response<bool>> Activate(long bookId)
        {
            return await Mediator.Send(new ActivateBookCommand(bookId));
        }

        /// <summary>
        /// Deactive Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Deactivate/{id}")]
        public async Task<Response<bool>> Deactivate(long bookId)
        {
            return await Mediator.Send(new DeactivateBookCommand(bookId));
        }
        /// <summary>
        /// Get One Book
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Get/{id}")]
        public async Task<Response<BookViewModel>> Get(long bookId)
        {
            var result = await _bookQuery.GetBook(bookId);

            return await Task.FromResult(Application.Contract.Response.Ok<BookViewModel>
                ("Success", result));
        }
    }
}
