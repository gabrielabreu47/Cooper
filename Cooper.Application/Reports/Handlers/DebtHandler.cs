using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Reports.Interfaces;
using Cooper.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cooper.Application.Reports.Handlers
{
    public class DebtHandler : IDebtHandler
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public DebtHandler(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        public Task GetPendingBills()
        {
            var bills = _billService.Query()
                .Where(x => x.State == BillStatus.Pending.ToInt())
                .Include(x => x.Products);

            return Task.FromResult(_mapper.Map<BillDto>(bills));
        }
    }
}
