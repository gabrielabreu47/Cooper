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
        public int Sku { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }

        public ProductPrice GetProductPrice()
        {
            return ProductPrices.OrderByDescending(x => x.Date).First();
        }
    }

    public class ProductPrice : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
