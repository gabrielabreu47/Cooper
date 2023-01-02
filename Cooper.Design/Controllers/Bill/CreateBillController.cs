using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Handlers;
using Cooper.Application.Bills.Interfaces;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Handlers;
using Cooper.Application.Products.Interfaces;

namespace Cooper.Design.Controllers.Bill
{
    public interface ICreateBillController
    {
        Task<ProductDto> GetProduct(string code);
        Task<(bool, string)> AddProduct(CreateBillProductDto product, List<CreateBillProductDto> products);
        Task<BillDto> Bill(CreateBillDto createBillModel);
        Task PrintBill(BillDto bill);
    }
    public class CreateBillController : ICreateBillController
    {
        private readonly IBillHandler _billHandler;
        private readonly IProductHandler _productHandler;
        private readonly IMapper _mapper;

        public CreateBillController(IBillHandler billHandler, IProductHandler productHandler, IMapper mapper)
        {
            _billHandler = billHandler;
            _productHandler = productHandler;
            _mapper = mapper;
        }
        public async Task<(bool, string)> AddProduct(CreateBillProductDto product, List<CreateBillProductDto> products)
        {
            try
            {
                await _productHandler.ValidateProductCanBeBilled(product);
            }
            catch(Exception ex)
            {
                return (false, ex.Message);
            }

            products.Add(product);

            return (true, string.Empty);
        }

        public async Task<BillDto> Bill(CreateBillDto createBillModel)
        {
            var bill = await _billHandler.Create(createBillModel);

            return bill;
        }

        public async Task<ProductDto> GetProduct(string code)
        {
            return await _productHandler.GetByCode(code);
        }

        public Task PrintBill(BillDto bill)
        {
            throw new NotImplementedException();
        }
    }
}
