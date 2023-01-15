using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace Cooper.Application.Bills.Handlers
{
    public class BillHandler
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

            query = query.Where(x => x.Date >= startDate && x.Date <= endDate);

            query = orderByAscending ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);

            var bills = query
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductPrices)
                .AsNoTracking()
                .ToList();

            List<BillDto> billDtos = new();

            foreach(var bill in bills)
            {
                var billProductsDto = bill.Products
                    .Select(x => 
                    _mapper.Map<BillProduct, BillProductDto>(x, opt =>
                        opt.AfterMap((src, dest) =>
                            dest.Price = src.SelledAsWholesale 
                            ? src.Product.GetProductPrice(bill.Date).WholesalePrice 
                            : src.Product.GetProductPrice(bill.Date).UnitPrice)))
                    .ToList();

                var billDto = _mapper.Map<BillDto>(bill);

                billDto.Products = billProductsDto;

                billDtos.Add(billDto);
            }

            return Task.FromResult(billDtos);
        }

        public virtual async Task<BillDto> Create(CreateBillDto billDto)
        {
            foreach(var product in billDto.Products)
            {
                await _productHandler.ValidateProductCanBeBilled(product);
            }

            var bill = _mapper.Map<Bill>(billDto);

            await _billService.Create(bill);

            var billProducts = bill.Products.ToList();

            List<UpdateProductStockDto> updateProductStocks = new();

            foreach(var billProduct in billProducts)
            {
                var product = await _productHandler.GetByIdAsNoTracking(billProduct.ProductId);

                var updateProductStock = new UpdateProductStockDto
                {
                    ProductId = billProduct.ProductId,
                    Stock = product.Stock - billProduct.Stock,
                };

                updateProductStocks.Add(updateProductStock);
            }

            await _productHandler.UpdateProductsStock(updateProductStocks, true);

            return _mapper.Map<BillDto>(bill);
        }

        public virtual async Task UpdateStatus(int billId, BillStatus status)
        {
            var bill = await _billService.GetByIdAsync(billId);

            bill.State = status.ToInt();

            await _billService.Update(bill);
        }

        public async Task<BillDto> GetById(int id)
        {
            var bill = await _billService.Query().Where(x => x.Id == id)
                .Include(x => x.Products)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductPrices)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var billProductsDto = bill.Products
                    .Select(x =>
                    _mapper.Map<BillProduct, BillProductDto>(x, opt =>
                        opt.AfterMap((src, dest) =>
                            dest.Price = src.SelledAsWholesale
                            ? src.Product.GetProductPrice(bill.Date).WholesalePrice
                            : src.Product.GetProductPrice(bill.Date).UnitPrice)))
                    .ToList();

            var billDto = _mapper.Map<BillDto>(bill);

            billDto.Products = billProductsDto;

            return billDto;
        }
    }
}
