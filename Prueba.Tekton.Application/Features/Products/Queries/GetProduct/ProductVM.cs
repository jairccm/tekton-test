namespace Prueba.Tekton.Application.Features.Products.Queries.GetProduct
{
    public class ProductVM
    {
        public Guid Id { get; set; }
        public string ProductId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public String StatusName { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalPrice { 
            
            get {
                return this.Price * (100 - this.Discount) / 100;
            } 
        }
    }
}
