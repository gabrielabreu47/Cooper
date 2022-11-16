using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Bills.Dtos
{
    public class BillDto
    {
    }

    public class PrintBillDto
    {

    }

    public class CreateBillDto
    {
        public List<BillProductDto> Products { get; set; }
    }

    public class BillProductDto
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }

    public class ListBillDto
    {

    }
}
