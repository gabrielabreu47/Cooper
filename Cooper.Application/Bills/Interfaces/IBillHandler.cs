using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Core.Entities;
using System.Linq.Expressions;

namespace Cooper.Application.Bills.Interfaces
{
    public interface IBillHandler
    {
        Task<IncomeReportDto> GetIncomesReport(DateTime startDate, DateTime endDate);
        Task<BillDto> GetById(int id);

        Task<List<BillDto>> Get(BillStatus status, DateTime? startDate = null,
            DateTime? endDate = null, Expression<Func<Bill, bool>>? filter = null);

        Task<List<BillDto>> Get(DateTime? startDate = null,
            DateTime? endDate = null, Expression<Func<Bill, bool>>? filter = null);

        Task<BillDto> Create(CreateBillDto billDto);

        Task UpdateStatus(int billId, BillStatus status);
    }
}
