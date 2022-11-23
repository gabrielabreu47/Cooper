using Cooper.Core.Entities.Generic;

namespace Cooper.Core.Entities
{
    public class Bill : BaseEntity
    {
        public Bill()
        {
            Products = new HashSet<BillProduct>();
        }

        public DateTimeOffset Date { get; set; }
        public string? ClientName { get; set; }
        public string? RNC { get; set; }
        public int State { get; set; }
        public virtual ICollection<BillProduct> Products { get;}
    }

    public class BillProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public int BillId { get; set; }
        public int Stock { get; set; }
        public bool SelledAsWholesale { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
