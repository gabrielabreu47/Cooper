using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cooper.Application.Products.Handlers
{
    public class ProductHandler
    {
        protected readonly IProductService _productService;
        protected readonly IMapper _mapper;

        public ProductHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public Task<List<ListProductDto>> Get(Expression<Func<Product, bool>>? filter = null)
        {
            var query = _productService.Query();
            
            if(filter != null) query = query.Where(filter);
                
            query = query.Include(x => x.ProductPrices);

            var result = query.ToList();

            var productDto = _mapper.Map<List<ListProductDto>>(result);

            return Task.FromResult(productDto);
        }

        protected async Task<Product> GetEntityById(int id)
        {
            var product = await _productService.Query()
                .Where(x => x.Id == id)
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductStockDetails)
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productService.Query()
                .Where(x => x.Id == id)
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductStockDetails)
                .FirstOrDefaultAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<TDto> GetById<TDto>(int id) where TDto : class
        {
            var product = await GetEntityById(id);

            var productDto = _mapper.Map<TDto>(product);

            return productDto;
        }

        public async Task<ProductDto> GetByIdAsNoTracking(int id)
        {
            var product = await _productService.Query()
                .Where(x => x.Id == id)
                .Include(x => x.ProductPrices)
                .Include(x => x.ProductStockDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public async Task<bool> Create(CreateProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                await _productService.Create(product);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Update(int id, UpdateProductDto productDto)
        {
            try
            {
                if (productDto.Id != id) throw new Exception("Id doesn't match");

                Product product = await GetEntityById(id);

                var productStockDetail = product.GetProductStockDetail();

                if(productStockDetail.StockCountAsWholesale != productDto.StockCountAsWholesale
                    || productStockDetail.StockCountAsRetail != productDto.StockCountAsRetail)
                {
                    product.ProductStockDetails = new List<ProductStockDetail>
                    {
                        new ProductStockDetail
                        {
                            ProductId = id,
                            Date= DateTime.Now,
                            StockCountAsRetail = productDto.StockCountAsRetail,
                            StockCountAsWholesale= productDto.StockCountAsWholesale
                        }
                    };
                }

                _mapper.Map(productDto, product);

                await _productService.Update(product);

                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _productService.Delete(id);

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
