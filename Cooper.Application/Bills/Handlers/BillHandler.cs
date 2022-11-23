using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;

namespace Cooper.Application.Bills.Handlers
{
    public class BillHandler : IBillHandler
    {
        protected readonly IBillService _billService;
        protected readonly IMapper _mapper;
        protected readonly IProductHandler _productHandler;

        public BillHandler(IBillService billService, IProductHandler productHandler, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
            _productHandler = productHandler;
        }

        public virtual async Task<List<BillDto>> Get(BillStatus status, DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            var query = _billService.Query().Where(x => x.State == status.ToInt());

            var result = await Get(query, startDate, endDate, orderByAscending);

            return result;
        }

        public virtual async Task<List<BillDto>> Get(DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            var query = _billService.Query();

            var result =  await Get(query, startDate, endDate, orderByAscending);

            return result;
        }

        private Task<List<BillDto>> Get(IQueryable<Bill> query, DateTime? startDate = null,
            DateTime? endDate = null, bool orderByAscending = true)
        {
            if (endDate == null) endDate = DateTime.Now;

            if (startDate == null) startDate = endDate.Value.AddDays(-10).Date;

            query.Where(x => x.Date >= startDate && x.Date <= endDate);

            query = orderByAscending ? query.OrderBy(x => x.Date) : query.OrderByDescending(x => x.Date);

            var bills = query.ToList();

            var billDtos = _mapper.Map<List<BillDto>>(bills);

            return Task.FromResult(billDtos);
        }

        public virtual async Task Create(CreateBillDto billDto)
        {
            foreach(var product in billDto.Products)
            {
                await _productHandler.ValidateProductCanBeBilled(product);
            }

            var bill = _mapper.Map<Bill>(billDto);

            await _billService.Create(bill);
        }

        public virtual async Task UpdateStatus(int billId, BillStatus status)
        {
            var bill = await _billService.GetByIdAsNoTrackingAsync(billId);

            bill.State = status.ToInt();

            await _billService.Update(billId, bill);
        }
    }
}
