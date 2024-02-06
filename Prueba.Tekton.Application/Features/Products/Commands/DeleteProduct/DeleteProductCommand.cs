using MediatR;

namespace Prueba.Tekton.Application.Features.Products.Commands.DeleteProduct
{
    public  class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
