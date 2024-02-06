namespace Prueba.Tekton.Domain
{
    public class Product
    {
        
        public Guid Id { get; set; }
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdateBy { get; set; }
    }
}
