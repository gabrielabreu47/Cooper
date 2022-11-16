using Cooper.Application.Generic.Dtos;

namespace Cooper.Application.Products.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int Amount { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ListProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sku { get; set; }
        public int Amount { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int Amount { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
    }
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int Amount { get; set; }
    }

    public class UpdateProductPriceDto
    {
        public int ProductId { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
