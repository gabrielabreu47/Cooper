using AutoMapper;
using Cooper.Application.Bills.Dtos;
using Cooper.Application.Bills.Enums;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Enums;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Cooper.Core.Extensions;

namespace Cooper.Application.Products.Handlers
{
    public class ProductAndPriceHandler : ProductHandler, IProductHandler
    {
        private readonly IProductPriceService _productPriceService;

        public ProductAndPriceHandler(IProductPriceService productPriceService, IProductService productService, IMapper mapper)
            : base(productService, mapper)
        {
            _productPriceService = productPriceService;
        }

        public async Task<bool> UpdateProductPrice(UpdateProductPriceDto productPriceDto)
        {
            try
            {
                var product = _mapper.Map<ProductPrice>(productPriceDto);

                product.Date = DateTime.Now;

                await _productPriceService.Create(product);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<int> GetStock(int productId)
        {
            var product = await  _productService.GetByIdAsNoTrackingAsync(productId);

            if (product == null)
            {
                var errorMessage = ProductErrorMessages.ProductDosntExists.GetDescription();

                errorMessage = errorMessage.Replace(ProductErrorMessageKeys.Id.GetDescription(), productId.ToString());

                throw new Exception(errorMessage);
            }
            return product.Stock;
        }

        public async Task<bool> ValidateAvailabilityInStock(int productId, int amount)
        {
            var stock = await GetStock(productId);

            return stock >= amount;
        }

        public async Task ValidateProductCanBeBilled(CreateBillProductDto product)
        {
            var canBillCurrentProduct = await ValidateAvailabilityInStock(product.ProductId, product.Stock);

            if (!canBillCurrentProduct)
            {
                var errorMessage = BillErrorMessages.InsufficientStock.GetDescription();

                errorMessage = errorMessage.Replace(BillErrorMessageKeys.Product.GetDescription(), product.Name);

                throw new Exception(errorMessage);
            }
        }
    }
}
