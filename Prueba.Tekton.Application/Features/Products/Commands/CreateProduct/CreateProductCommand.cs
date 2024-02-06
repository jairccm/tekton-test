using MediatR;

namespace Prueba.Tekton.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string ProductId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Status { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
