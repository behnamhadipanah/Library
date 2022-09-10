using LibrarySystem.Application.Commands.BindingCommands;
using LibrarySystem.Application.Commands.CategoryCommands;
using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Binding;
using LibrarySystem.Infrastructure.Contracts.Binding;
using LibrarySystem.Infrastructure.Queries.BindingQuery;
using LibrarySystem.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class BindingController : ApiBaseController
    {
        private readonly IBindingQuery _bindingQuery;
        public BindingController(IBindingQuery bindingQuery)
        {
            _bindingQuery = bindingQuery;
        }
        /// <summary>
        /// Get Bindings List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<Response<List<BindingViewModel>>> Get()
        {
            var result = _bindingQuery.GetBindings();
            return await Task.FromResult(Application.Contract.Response.Ok<List<BindingViewModel>>
                ("Success", result.Result));
        }
        /// <summary>
        /// Add Binding 
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response<bool>> Add([FromBody] CreateBindingViewModel model)
        {
            return await Mediator.Send(new CreateBindingCommand(model));

        }

        /// <summary>
        /// Update Binding
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Response<bool>> Edit([FromBody] EditBindingViewModel model)
        {
            return await Mediator.Send(new UpdateBindingCommand(model));
        }
        /// <summary>
        /// Delete Binding
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Response<bool>> Delete(long bindingId)
        {
            return await Mediator.Send(new DeleteBindingCommand(bindingId));
        }
        /// <summary>
        /// Activate Binding
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Activate/{id}")]
        public async Task<Response<bool>> Activate(long bindingId)
        {
            return await Mediator.Send(new ActivateBindingCommand(bindingId));
        }

        /// <summary>
        /// Deactive Binding
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Deactivate/{id}")]
        public async Task<Response<bool>> Deactivate(long bindingId)
        {
            return await Mediator.Send(new DeactivateBindingCommand(bindingId));
        }
        /// <summary>
        /// Get One Binding
        /// </summary>
        /// <param name="bindingId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Get/{id}")]
        public async Task<Response<BindingViewModel>> Get(long bindingId)
        {
            var result = await _bindingQuery.GetBinding(bindingId);

            return await Task.FromResult(Application.Contract.Response.Ok<BindingViewModel>
                ("Success", result));
        }
    }
}
