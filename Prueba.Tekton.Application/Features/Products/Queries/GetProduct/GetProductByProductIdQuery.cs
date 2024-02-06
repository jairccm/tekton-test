using MediatR;

namespace Prueba.Tekton.Application.Features.Products.Queries.GetProduct
{
    public class GetProductByProductIdQuery : IRequest<ProductVM>
    {
        public String ProductId { get; set; }
    }
}
