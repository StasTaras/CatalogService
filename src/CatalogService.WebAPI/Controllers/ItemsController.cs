using CatalogService.Application.Items.Commands.CreateItem;
using CatalogService.Application.Items.Commands.CreateItem.Models;
using CatalogService.Application.Items.Commands.DeleteItem;
using CatalogService.Application.Items.Commands.UpdateItem;
using CatalogService.Application.Items.Commands.UpdateItem.Models;
using CatalogService.Application.Items.Queries;
using CatalogService.Application.Items.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ItemModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetItemQuery(id));
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ItemModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetListItemsQuery());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add(
            [FromBody] CreateItemModel itemModel,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateItemCommand(itemModel), cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = result.ItemId }, result);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateItemModel itemModel,
            CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateItemCommand(itemModel, id), cancellationToken);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteItemCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
