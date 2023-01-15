using Cooper.Application.Generic.Dtos;
using System.ComponentModel;

namespace Cooper.Application.Products.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sku { get; set; }
        public int Stock { get; set; }
        public int StockCountAsRetail { get; set; }
        public int StockCountAsWholesale { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class PriceDto
    {
        [DisplayName("Fecha")]
        public DateTime Date { get; set; }
        [DisplayName("Precio al Detalle")]
        public decimal WholesalePrice { get; set; }
        [DisplayName("Precio al por Mayor")]
        public decimal UnitPrice { get; set; }
    }

    public class ListProductDto
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [DisplayName("Cantidad")]
        public int Stock { get; set; }
        [DisplayName("Precio al Detalle")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Precio al por Mayor")]
        public decimal WholesalePrice { get; set; }
    }

    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int StockCountAsRetail { get; set; }
        public int StockCountAsWholesale { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
    }
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockCountAsRetail { get; set; }
        public int StockCountAsWholesale { get; set; }
    }

    public class UpdateProductStockDto
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
    }

    public class UpdateProductPriceDto
    {
        public int ProductId { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
