using AutoMapper;
using Cooper.Application.Products.Dtos;
using Cooper.Application.Products.Interfaces;
using Cooper.Core.Entities;
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

        public Task<List<ListProductDto>> Get(int top = 10, int skip = 0, Expression<Func<Product,
            object>>? orderBy = null, bool orderByAscending = true)
        {
            var query = _productService.Query();

            if(orderBy != null) _ = orderByAscending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            var result = query.Skip(skip).Take(top).ToList();

            var productDto = _mapper.Map<List<ListProductDto>>(result);

            return Task.FromResult(productDto);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

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
                var product = _mapper.Map<Product>(productDto);

                await _productService.Update(id, product);

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
