using Cooper.Application.Bills.Enums;
using Cooper.Application.Generic.Dtos;

namespace Cooper.Application.Bills.Dtos
{
    public class BillDto : BaseDto
    {
        public DateTimeOffset Date { get; set; }
        public string ClientName { get; set; }
        public string? RNC { get; set; }
        public BillStatus State { get; set; }
        public decimal SubTotal 
        {
            get
            {
                return Products.Sum(x => x.PriceTotal);
            }
        }
        public decimal Total
        {
            get
            {
                return Taxes.HasValue ? SubTotal + Taxes.Value : SubTotal;
            }
        }

        public decimal? Taxes
        {
            get
            {
                return Products.Sum(x => x.Taxes);
            }
        }
        public List<BillProductDto> Products { get; set; }
    }
    public class BillProductDto
    {
        public int ProductId { get; set; }
        public int BillId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public decimal PriceTotal
        {
            get
            {
                return Price * Stock;
            }
        }
        public decimal? Taxes 
        {
            get
            {
                return PriceTotal * Convert.ToDecimal(0.18); 
            }
        }
        public bool SelledAsWholesale { get; set; }
    }

    public class CreateBillDto
    {
        public string ClientName { get; set; }
        public string? RNC { get; set; }
        public BillStatus Status { get; set; }
        public List<CreateBillProductDto> Products { get; set; }
    }
    public class CreateBillProductDto
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public string Name { get; set; }
        public bool SelledAsWholesale { get; set; }
    }

    public class PrintBillDto
    {
        public List<PrintBillProductDto> Products { get; set; }
    }
    public class PrintBillProductDto
    {

    }
}
