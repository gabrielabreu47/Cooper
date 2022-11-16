using Cooper.Core.Entities.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Sku { get; set; }
        public int Amount { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
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
