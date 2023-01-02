using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;

namespace Cooper.Application.Bills.Interfaces
{
    public interface IBillHandler
    {
        Task<List<BillDto>> Get(BillStatus status, DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true);

        Task<List<BillDto>> Get(DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true);

        Task<BillDto> Create(CreateBillDto billDto);

        Task UpdateStatus(int billId, BillStatus status);
    }
}
