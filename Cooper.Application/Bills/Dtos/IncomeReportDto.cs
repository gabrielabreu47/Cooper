using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Bills.Dtos
{
    public class IncomeReportDto
    {
        public int PendingBills { get; set; }
        public int InvoicedBills { get; set; }
        public decimal PendingAmount { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
