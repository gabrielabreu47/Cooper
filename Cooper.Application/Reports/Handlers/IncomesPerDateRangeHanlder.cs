using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Reports.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Cooper.Application.Reports.Handlers
{
    public class IncomesPerDateRangeHanlder : IIncomesPerDateRangeHandler
    {
        private readonly IBillService _billService;
        private readonly IMapper _mapper;

        public IncomesPerDateRangeHanlder(IBillService billService, IMapper mapper)
        {
            _billService = billService;
            _mapper = mapper;
        }

        public async Task<decimal> GetAllIncomes(DateTime startDate, DateTime endDate)
        {
            var totalIncomes = await GetIncomes(startDate, endDate, _billService.Query());

            return totalIncomes;
        }

        public async Task<decimal> GetAllIncomes(DateTime startDate, DateTime endDate, BillStatus status)
        {
            var query = _billService.Query().Where(x => x.State == status.ToInt());

            var totalIncomes = await GetIncomes(startDate, endDate, query);

            return totalIncomes;
        }

        private async Task<decimal> GetIncomes(DateTime startDate, DateTime endDate, IQueryable<Bill> query)
        {
            var bills = await query
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ToListAsync();

            var billDtos = _mapper.Map<List<BillDto>>(bills);

            return billDtos.Sum(x => x.Total);
        }
    }
}
