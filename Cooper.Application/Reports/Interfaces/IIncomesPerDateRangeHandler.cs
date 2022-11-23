using Cooper.Application.Bills.Enums;

namespace Cooper.Application.Reports.Interfaces
{
    public interface IIncomesPerDateRangeHandler
    {
        Task<decimal> GetAllIncomes(DateTime startDate, DateTime endDate);
        Task<decimal> GetAllIncomes(DateTime startDate, DateTime endDate, BillStatus status);
    }
}
