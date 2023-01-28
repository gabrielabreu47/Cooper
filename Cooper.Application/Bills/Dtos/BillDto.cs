using Cooper.Application.Bills.Enums;
using Cooper.Application.Generic.Dtos;

namespace Cooper.Application.Bills.Dtos
{
    public class BillDto : BaseDto
    {
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public string? Phone { get; set; }
        public BillStatus State { get; set; }
        public decimal Total
        {
            get
            {
                return Products.Sum(x => x.PriceTotal);
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
        public bool SelledAsWholesale { get; set; }
    }

    public class CreateBillDto
    {
        public string ClientName { get; set; }
        public string? Phone { get; set; }
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
