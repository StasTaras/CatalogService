using CatalogService.Application.Categories.Commands.CreateCategory;
using CatalogService.Application.Categories.Commands.CreateCategory.Models;
using CatalogService.Application.Categories.Commands.UpdateCategory;
using CatalogService.Application.Categories.Commands.UpdateCategory.Models;
using CatalogService.Application.Categories.Queries;
using CatalogService.Application.Categories.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CatalogService.Application.Categories.Commands.DeleteCategory;

namespace CatalogService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CategoryModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetListCategoriesQuery());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CategoryModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(
            [FromBody] CreateCategoryModel categoryModel,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateCategoryCommand(categoryModel), cancellationToken);
            return CreatedAtAction(nameof(Get), new {id = result.CategoryId}, result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateCategoryModel categoryModel,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCategoryCommand(categoryModel, id), cancellationToken);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(CategoryModel), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
