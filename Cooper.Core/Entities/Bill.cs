using Cooper.Core.Entities.Generic;

namespace Cooper.Core.Entities
{
    public class Bill : BaseEntity
    {
        public DateTimeOffset Date { get; set; }
        public string ClientName { get; set; }
        public string? RNC { get; set; }
        public int State { get; set; }
    }

    public class BillProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public int BillId { get; set; }
        public int Amount { get; set; }
        public bool SelledAsWholesale { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
