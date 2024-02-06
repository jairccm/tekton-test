using MediatR;

namespace Prueba.Tekton.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
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
