using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.Tekton.Application.Features.Products.Commands.CreateProduct;
using Prueba.Tekton.Application.Features.Products.Commands.DeleteProduct;
using Prueba.Tekton.Application.Features.Products.Commands.UpdateProduct;
using Prueba.Tekton.Application.Features.Products.Queries.GetProduct;
using System.Net;

namespace Prueba.Tekton.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductVM), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductVM>> GetProductById(String id)
        {
            var query = new GetProductByProductIdQuery() { ProductId = id};
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}",Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateProduct(Guid id,[FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }

    }
}
