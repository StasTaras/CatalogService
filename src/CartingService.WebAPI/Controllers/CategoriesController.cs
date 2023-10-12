using CatalogService.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CancellationToken cancellationToken)
        {
            //var category = new Category
            //{
            //    Name = "Sample Category",
            //    Image = "https://example.com/sample.jpg"
            //};

            //_applicationDbContext.Categories.Add(category);
            //await _applicationDbContext.SaveChangesAsync(cancellationToken);


            return Ok("categories");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok("categories");
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok("categories");
        }
    }
}
