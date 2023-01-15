using Cooper.Core.Entities.Generic;

namespace Cooper.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductPrices = new HashSet<ProductPrice>();
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<ProductStockDetail> ProductStockDetails { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }

        public ProductStockDetail GetProductStockDetail()
        {
            return ProductStockDetails.OrderByDescending(x => x.Date).First();
        }

        public ProductPrice GetProductPrice()
        {
            return ProductPrices.OrderByDescending(x => x.Date).First();
        }

        public ProductPrice GetProductPrice(DateTimeOffset date)
        {
            return ProductPrices
                .Where(x => x.Date <= date)
                .OrderByDescending(x => x.Date)
                .First();
        }
    }

    public class ProductStockDetail : BaseEntity
    {
        public DateTime Date { get; set; }
        public int StockCountAsRetail { get; set; }
        public int StockCountAsWholesale { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

    public class ProductPrice : BaseEntity
    {
        public DateTime Date { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
