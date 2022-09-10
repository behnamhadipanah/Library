using LibrarySystem.Application.Commands.CategoryCommands;
using LibrarySystem.Application.Commands.CategoryCommands;
using LibrarySystem.Application.Contract;
using LibrarySystem.Application.Contract.Category;
using LibrarySystem.Infrastructure.Contracts.Category;
using LibrarySystem.Infrastructure.Queries.CategoryQuery;
using LibrarySystem.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiBaseController
    {
        private readonly ICategoryQuery _categoryQuery;
        public CategoryController(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }
        /// <summary>
        /// Get Categorys List
        /// </summary>
        /// <returns></returns>
        [HttpGet]  
        public async Task<Response<List<CategoryViewModel>>> Get()
        {
            var result = _categoryQuery.GetCategories();
            return await Task.FromResult(Application.Contract.Response.Ok<List<CategoryViewModel>>
                ("Success", result.Result));
        }
        /// <summary>
        /// Add Category 
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response<bool>> Add([FromBody] CreateCategoryViewModel model)
        {
            return await Mediator.Send(new CreateCategoryCommand(model));

        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param data="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<Response<bool>> Edit([FromBody] EditCategoryViewModel model)
        {
            return await Mediator.Send(new UpdateCategoryCommand(model));
        }
        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<Response<bool>> Delete(long categoryId)
        {
            return await Mediator.Send(new DeleteCategoryCommand(categoryId));
        }
        /// <summary>
        /// Activate Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Activate/{id}")]
        public async Task<Response<bool>> Activate(long categoryId)
        {
            return await Mediator.Send(new ActivateCategoryCommand(categoryId));
        }

        /// <summary>
        /// Deactive Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Deactivate/{id}")]
        public async Task<Response<bool>> Deactivate(long categoryId)
        {
            return await Mediator.Send(new DeactivateCategoryCommand(categoryId));
        }
        /// <summary>
        /// Get One Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("/api/[controller]/Get/{id}")]
        public async Task<Response<CategoryViewModel>> Get(long categoryId)
        {
            var result = await _categoryQuery.GetCategory(categoryId);

            return await Task.FromResult(Application.Contract.Response.Ok<CategoryViewModel>
                ("Success", result));
        }
    }
}
