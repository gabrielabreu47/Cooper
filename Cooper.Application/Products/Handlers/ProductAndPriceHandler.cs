using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;

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
    }
}
