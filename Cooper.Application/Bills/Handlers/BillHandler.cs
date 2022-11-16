using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;

namespace Cooper.Application.Bills.Handlers
{
    public class BillHandler
    {
        protected readonly IBillService _billService;
        protected readonly IMapper _mapper;

        public BillHandler(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        public async Task<List<ListBillDto>> Get(BillStatus status, DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            var query = _billService.Query().Where(x => x.State == status.ToInt());

            var result = await Get(query, startDate, endDate, orderByAscending);

            return result;
        }

        public async Task<List<ListBillDto>> Get(DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            var query = _billService.Query();

            var result =  await Get(query, startDate, endDate, orderByAscending);

            return result;
        }

        private Task<List<ListBillDto>> Get(IQueryable<Bill> query, DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            if (endDate == null) endDate = DateTime.Now;

            if (startDate == null) startDate = endDate.Value.AddDays(-10).Date;

            query.Where(x => x.Date >= startDate && x.Date <= endDate);

            _ = orderByAscending ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);

            var bills = query.ToList();

            var billDtos = _mapper.Map<List<ListBillDto>>(bills);

            return Task.FromResult(billDtos);
        }

        public async Task Create(CreateBillDto billDto)
        {
            var bill = _mapper.Map<Bill>(billDto);

            await _billService.Create(bill);
        }
    }
}
