using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooper.Application.Bills.Handlers
{
    public class BillReportHandler : BillHandler, IBillHandler
    {
        public BillReportHandler(IBillService billService, IProductHandler productHandler, IMapper mapper) 
            : base(billService, productHandler, mapper)
        {

        }

        public async Task<IncomeReportDto> GetIncomesReport(DateTime startDate, DateTime endDate)
        {
            var bills = await Get(startDate, endDate);

            var pendingBills = bills.Where(x => x.State == Enums.BillStatus.Pending).Count();
            var invoicedBills = bills.Where(x => x.State == Enums.BillStatus.Invoiced).Count();
            var paidAmount = bills.Where(x => x.State == Enums.BillStatus.Invoiced).Sum(x => x.Total);
            var pendingAmount = bills.Where(x => x.State == Enums.BillStatus.Pending).Sum(x => x.Total);

            return new IncomeReportDto
            {
                InvoicedBills = invoicedBills,
                PaidAmount = paidAmount,
                PendingAmount = pendingAmount,
                PendingBills = pendingBills
            };
        }
    }
}
